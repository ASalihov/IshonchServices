using System;
using System.Collections.Generic;
using System.Text;
using NewTests.OneCReference;
using System.Linq;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace NewTests
{
    public static class Extensions
    {
        public static void AppendWithLength(this StringBuilder builder, string value)
        {
            if (value != null)
            {
                builder.Append(Encoding.UTF8.GetByteCount(value));
                builder.Append(value);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var ish = new IshonchService(new ObjectCalculation
            {
                ID = Guid.NewGuid().ToString(),
                Type = "0",
                Status = "Новый",
                ContactPerson = "f4eb74be-6625-11e2-a005-50e54958fe81",
                LID = "Лид666",
                Buyer = "",
                LIDBuyer = "ddf",
                Circulation = "100", 
                Manager = Guid.NewGuid().ToString(),
                Comment = "CommentFromBPM 5000",
                Specification = "Спецификация 5000",
                DateExecute = DateTime.Now,
                DateDoc = DateTime.Now
            });

            var bpm = new IshonchService("1", "2");
            bpm.SendRequestToBPM();
            //ish.SendRequestTo1C();
             

            /*
            using (var db = new Context())
            {
                db.Guests.Add(new Guest
                {
                    Company = new Company(),
                    CompanyID = 1,
                    Name = "Name1"
                });
                db.SaveChanges();
            }
            /*


            bool? boo = null;
            boo = false;
            if (boo ?? false)
            {
                Console.WriteLine("boo");
            }
            
            */



            var dict = new Dictionary<string, string> { {"1", "11"}, {"11", "3434"}, {"2","22"}, {"3","33"}};
            foreach (KeyValuePair<string, string> pair in dict)
            {
                //Console.WriteLine(pair.Key + " - " + pair.Value);
            }

            string s = dict.ContainsKey("2") ? dict["2"] : "123";

            Console.WriteLine(s);

            string str = "192016-05-25 13:18:33192016-05-25 13:23:0382262427160000022928COMPLETE24Visa/MasterCard/Eurocard16Истинный28Рекомендателей1-04Visa00000091Волгоградская обл, г. Урюпинск, ул. Московская, д. 3,000010Uzbekistan2uz21+7(900) 000 - 00 - 80015empty@empty.com16Истинный28Рекомендателей091Волгоградская обл, г. Урюпинск, ул. Московская, д. 3,000010Uzbekistan2uz21+7(900) 000 - 00 - 8015empty@empty.com1289.236.239.110Uzbekistan192016-05-25 13:24:173RUB2ru82027985829Погашение займа1101141.3040.00040.0000100041.3041.3040.0053https://rmfinance.bpmonline.com/0/Nui/ViewModule.aspx40.001420160530133813";
            var encoding = Encoding.UTF8;
            var bytes = encoding.GetBytes(str);
            var hmac = new HMACMD5(encoding.GetBytes("6=TF^]3%8^V5[S79!Q7("));

            Console.WriteLine(ByteToString(hmac.ComputeHash(bytes)).ToLower());

            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.AppendWithLength(i.ToString());
            }
            Console.WriteLine(Encoding.UTF8.GetByteCount("150"));

            Console.WriteLine(DateTime.Now.Date.AddHours(5).ToLongTimeString());
            Console.Read();
        }
        public static string ByteToString(IEnumerable<byte> buff)
        {
            var sbinary = new StringBuilder();
            foreach (var t in buff)
            {
                sbinary.Append(t.ToString("X2")); // hex format
            }
            return sbinary.ToString();
        }

    }
}

