using System;
using System.Collections.Generic;
using System.Text;
using NewTests.OneCReference;
using NewTests.TestServiceBPM;

namespace NewTests
{
    public class IshonchService
    {
        private ObjectCalculation ObjectCalculation { get; set; }
        private string Param1 { get; set; }
        private string Param2 { get; set; }

        public IshonchService(ObjectCalculation objectCalculation)
        {
            this.ObjectCalculation = objectCalculation;
        }

        public IshonchService(string param1, string param2)
        {
            this.Param1 = param1;
            this.Param2 = param2;
        }

        public void SendRequestTo1C()
        {
            using (var service = new GetCirculation())
            {
                service.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
                service.Credentials = new System.Net.NetworkCredential("Admin", "123");

                var order = service.GetDoc(ObjectCalculation);
                if (order != null)
                {
                    Console.WriteLine(order);
                }
            }
        }
        public void SendRequestToBPM()
        {
            using (var service = new TestServiceBPM.ServiceClient())
            {
                var obj = new CostCalculationObj
                {
                    Id = new Guid("fa39a7dd-34e4-4ca0-83b0-d7503c55ffbf"),
                    Status = Guid.NewGuid(),
                    StartDate = DateTime.Now,
                    OrderPrice = 125,
                    UnitPrice = 126
                };


                var res = service.TestService(obj);
                if (res != null)
                {
                    Console.WriteLine(res);
                    Console.WriteLine(DateTime.MinValue);
                }
            }
        }
    }
}
