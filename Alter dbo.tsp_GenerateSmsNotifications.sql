USE [rmfinance]
GO

/****** Object: SqlProcedure [dbo].[tsp_GenerateSmsNotifications] Script Date: 25.04.2016 10:46:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].tsp_GenerateSmsNotifications
			
AS

BEGIN
	DECLARE		@ActiveStatus				UNIQUEIDENTIFIER = '3DF4F13B-C7E5-475A-BDCF-2CC320012B90', -- Состояние договора - Действующий
				@OverdueStatus				UNIQUEIDENTIFIER = 'EFDC08C3-FDBD-4403-B3EA-A80343F18018', -- Состояние договора - Просрочен
			    @CategoryPercent			UNIQUEIDENTIFIER = '9CAF0CCE-3AB3-4257-847D-4A5D4BB8E05F', -- Категория операции - Проценты по займу
	            @CategoryDebt				UNIQUEIDENTIFIER = '15F0B774-E715-418C-BEB1-A2C61CBAB18C', -- Категория операции - Основной долг
				@DayRateParam				UNIQUEIDENTIFIER = '136169F2-200C-41CD-B2B0-E047A6456881', -- Параметр  договора - Ставка в день
				@SmsNotifyPeriodicity		INT

				-- Записываем в переменную число-период уведомления для просроченных договоров
				SELECT @SmsNotifyPeriodicity = IntegerValue 
				  FROM SysSettingsValue ssv 
				  JOIN SysSettings ss ON ssv.SysSettingsId = ss.Id
				 WHERE ss.Code = 'SmsNotificationsPeriodicity'

	
	BEGIN TRANSACTION
		
		-- Pаписываем в таблицу для рассылки смс-уведомлений данные о том по каким договорам и какого типа нужно отправить смс.
		-- Для уведомлений:
		--		* за 2 дня до даты планового погашения (текущей)
		--		* в день даты планового погашения (текущей)
		INSERT INTO UsrSmsForSend 
		(
			   UsrContractId,
			   UsrSmsNotifType,
			   UsrSendDate,
			   UsrDebtAmount,
			   UsrRecipientPhone,
			   UsrPaymentDay,
			   UsrContractDate,
			   UsrContractNum
		)
		SELECT c.Id, 
			   CASE WHEN c.CurrentRepaymentDate = convert(DATE, GETDATE()) THEN 2						-- ТИП 2 - в день даты планового погашения (текущей)
					WHEN c.CurrentRepaymentDate = convert(DATE, dateadd(day, 2, getdate())) THEN 1      -- ТИП 1 - за 2 дня до даты планового погашения (текущей)
			   END,
			   CONVERT(DATE, GETDATE()), 
			   CASE WHEN c.CurrentRepaymentDate = convert(DATE, GETDATE()) 
						THEN (debt.Amount + intr.Amount)								  				-- в день даты планового погашения (текущей)
					WHEN c.CurrentRepaymentDate = convert(DATE, dateadd(day, 2, getdate())) 
						THEN (debt.Amount + intr.Amount) + (debt.Amount * cp_DayRate.FloatValue / 100)	-- за 2 дня до даты планового погашения (текущей)
			   END,
			   sau.Name,																					-- Номер телефон (логин пользователя)
			   c.CurrentRepaymentDate,
			   c.SignedOn,
			   c.Number
		  FROM Contract c
		  
		  JOIN Contact ctc ON c.ContactId = ctc.Id
		  JOIN SysAdminUnit sau ON ctc.Id = sau.ContactId
	 LEFT JOIN UsrSmsForSend uss ON uss.UsrContractId = c.Id AND									    -- проверяем нет ли уже смс по этому договору
									uss.UsrSendDate = convert(DATE, GETDATE())							-- и дата отправки должна быть сегодня	
										 
	 LEFT JOIN VwDebtAmount debt ON debt.ContractId = c.Id AND											-- выбираем основной долг из сумм к погашению по договору
								    debt.CategoryId = @CategoryDebt
										 
	 LEFT JOIN VwDebtAmount intr ON intr.ContractId = c.Id AND											-- выбираем проценты по займу из сумм к погашению по договору
								    intr.CategoryId = @CategoryPercent

	 LEFT JOIN ContractParameter cp_DayRate ON cp_DayRate.ContractId = c.Id AND
											   cp_DayRate.ParameterTypeId = @DayRateParam				-- Ставка в день

		 WHERE c.StatusId = @ActiveStatus AND
			   (c.CurrentRepaymentDate = CONVERT(DATE, GETDATE()) OR
				c.CurrentRepaymentDate = CONVERT(DATE, DATEADD(DAY, 2, GETDATE()))) AND 
			   uss.UsrSendDate IS NULL																	-- только те договора, у которых на сегодня ещё нет смс (условия JOIN выше)

		-- Pаписываем в таблицу для рассылки смс-уведомлений данные о том по каким договорам и какого типа нужно отправить смс.
		-- Для уведомлений:
		--		* каждые n дней после просрочки

		INSERT INTO UsrSmsForSend 
		(
			   UsrContractId,
			   UsrSmsNotifType,
			   UsrSendDate,
			   UsrDebtAmount,
			   UsrRecipientPhone,
			   UsrPaymentDay,
			   UsrContractDate,
			   UsrContractNum
		)
		SELECT c.Id, 
			   3,																			-- каждые n дней после просрочки
			   CONVERT(DATE, GETDATE()),
			   (debt.Amount + intr.Amount),
			   sau.Name,
			   c.CurrentRepaymentDate,
			   c.SignedOn,
			   c.Number
		  FROM Contract c
		  
		  JOIN Contact ctc ON c.ContactId = ctc.Id
		  JOIN SysAdminUnit sau ON ctc.Id = sau.ContactId

	 LEFT JOIN UsrSmsForSend uss ON uss.UsrContractId = c.Id AND							-- проверяем нет ли уже смс по этому договору
									uss.UsrSendDate = CONVERT(DATE, GETDATE())				-- и дата отправки должна быть сегодня	

	 LEFT JOIN VwDebtAmount debt ON debt.ContractId = c.Id AND								-- выбираем основной долг из сумм к погашению по договору
								    debt.CategoryId = @CategoryDebt
										 
	 LEFT JOIN VwDebtAmount intr ON intr.ContractId = c.Id AND								-- выбираем проценты по займу из сумм к погашению по договору
								    intr.CategoryId = @CategoryPercent

		 WHERE c.StatusId = @OverdueStatus AND
			   c.OverdueDays % @SmsNotifyPeriodicity = 0 AND								-- Количество дней просрочки делится на число-период уведомления нацело
			   uss.UsrSendDate IS NULL														-- только те договора, у которых на сегодня ещё нет смс (условия JOIN выше)										
		
	COMMIT TRANSACTION
END
---------------------------------------------------------------

select * from VwDebtAmount
select * from UsrSmsForSend
select * from PNLTransactionCategory

declare
@ActiveStatus				UNIQUEIDENTIFIER = '3DF4F13B-C7E5-475A-BDCF-2CC320012B90', -- Состояние договора - Действующий
@OverdueStatus				UNIQUEIDENTIFIER = 'EFDC08C3-FDBD-4403-B3EA-A80343F18018', -- Состояние договора - Просрочен
@CategoryPercent			UNIQUEIDENTIFIER = '9CAF0CCE-3AB3-4257-847D-4A5D4BB8E05F', -- Категория операции - Проценты по займу
@CategoryDebt				UNIQUEIDENTIFIER = '15F0B774-E715-418C-BEB1-A2C61CBAB18C', -- Категория операции - Основной долг
@DayRateParam				UNIQUEIDENTIFIER = '136169F2-200C-41CD-B2B0-E047A6456881', -- Параметр  договора - Ставка в день
@SmsNotifyPeriodicity		INT
-- Записываем в переменную число-период уведомления для просроченных договоров
SELECT @SmsNotifyPeriodicity = IntegerValue 
FROM SysSettingsValue ssv 
JOIN SysSettings ss ON ssv.SysSettingsId = ss.Id
WHERE ss.Code = 'SmsNotificationsPeriodicity'

		SELECT c.Id, 
			   3,																			-- каждые n дней после просрочки
			   CONVERT(DATE, GETDATE()),
			   (debt.Amount + intr.Amount),
			   sau.Name,
			   c.CurrentRepaymentDate,
			   c.SignedOn,
			   c.Number
		  FROM Contract c
		  
		  JOIN Contact ctc ON c.ContactId = ctc.Id
		  JOIN SysAdminUnit sau ON ctc.Id = sau.ContactId

	 LEFT JOIN UsrSmsForSend uss ON uss.UsrContractId = c.Id AND							-- проверяем нет ли уже смс по этому договору
									uss.UsrSendDate = CONVERT(DATE, GETDATE())				-- и дата отправки должна быть сегодня	

	 LEFT JOIN VwDebtAmount debt ON debt.ContractId = c.Id AND								-- выбираем основной долг из сумм к погашению по договору
								    debt.CategoryId = @CategoryDebt
										 
	 LEFT JOIN VwDebtAmount intr ON intr.ContractId = c.Id AND								-- выбираем проценты по займу из сумм к погашению по договору
								    intr.CategoryId = @CategoryPercent

		 WHERE c.StatusId = @OverdueStatus AND
			   c.OverdueDays % @SmsNotifyPeriodicity = 0 AND								-- Количество дней просрочки делится на число-период уведомления нацело
			   uss.UsrSendDate IS NULL														-- только те договора, у которых на сегодня ещё нет смс (условия JOIN выше)										
			--update UsrSmsForSend set UsrSended = 0 where id = '68E848AA-2F73-4A4C-8516-BB24828E2E68'

			select * from EmailTemplate where id = '5A617AED-B104-49D6-B88F-AF9636D0662B'

			insert into EmailTemplate (Id, Name, [Subject], PriorityId, Body, IsHtmlBody)values('D063E335-C78D-4734-80AA-A8C4859168E0', 'Уведомление о необходимости погашения (за 2 дня)', 'Уведомление о необходимости погашения (за 2 дня)', 'AB96FA02-7FE6-DF11-971B-001D60E938C6', 'Напоминаем, что сумма очередного платежа составляет {0} руб. Дата платежа {1}. СПРИНТ', 0)
			insert into EmailTemplate (Id, Name, [Subject], PriorityId, Body, IsHtmlBody)values('E34317AE-FA24-4CD7-8965-8FDE18DF2295', 'Уведомление о необходимости погашения (в расчетную дату)', 'Уведомление о необходимости погашения (в расчетную дату)', 'AB96FA02-7FE6-DF11-971B-001D60E938C6', 'Напоминаем, сумма платежа: {0}руб, необходимо оплатить до {1}. СПРИНТ', 0)
			insert into EmailTemplate (Id, Name, [Subject], PriorityId, Body, IsHtmlBody)values('8D5B3AB6-6766-4119-84C7-099F9AD99AA8', 'Уведомление с требованием о погашении (каждые 5 дней)', 'Уведомление с требованием о погашении (каждые 5 дней)', 'AB96FA02-7FE6-DF11-971B-001D60E938C6', 'Напоминаем, у Вас имеется задолженность по договору № {0} от {1}. Необходимо внести платеж. СПРИНТ  ', 0)

