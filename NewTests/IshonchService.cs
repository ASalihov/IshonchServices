using System;
using System.Collections.Generic;
using System.Text;
using NewTests.OneCReference;

namespace NewTests
{
    public class IshonchService
    {
        private ObjectCalculation ObjectCalculation { get; set; }

        public IshonchService(ObjectCalculation objectCalculation)
        {
            this.ObjectCalculation = objectCalculation;
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

        /***
         * var request = (HttpWebRequest)WebRequest.Create("http://94.158.53.231:5200/1/rest/TestServiceBpm/TestService");


            //var data = Encoding.ASCII.GetBytes("{\"statusName\":\"test\",\"statusId\":\"eere\"}");
            var data = Encoding.ASCII.GetBytes("<TestService xmlns=\"http://www.fuzh.com\">" +
                       "<statusName>" +
                       "test" +
                       "</statusName>" +
                       "<statusId>" +
                       "eere" +
                       "</statusId>" +
                       "</TestService>");

            request.Method = "POST";
            request.ContentType = "application/json";
            //request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.Accept = "application/json";
            //request.Accept = "application/json";

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            
            /*

            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["statusName"] = "hello";
                values["statusId"] = "world";

                var response = client.UploadValues("http://94.158.53.231:5200/1/rest/TestServiceBpm/TestService", values);

                var responseString = Encoding.Default.GetString(response);
                Console.WriteLine(responseString);
            }
            Console.WriteLine(responseString);
         ***/

    }
}
