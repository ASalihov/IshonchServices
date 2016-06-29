using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;

namespace NewTests
{
    public class XmlParser
    {
        public void LoadXmlDocument()
        {
            var dict = new Dictionary<string, string>
            {
                {"_PassportNumber"          , ""},
                {"_DateOfIssue"             , ""},
                {"_DateOfExpiry"            , ""},
                {"_DateOfBirth"             , ""},
                {"_Name"                    , ""},
                {"_LastName"                , ""},
                {"_Sex"                     , ""},
                {"_MRZ1"                    , ""},
                {"_MRZ2"                    , ""},
                {"_TopFamiliyasi"           , ""},
                {"_TopIsmi"                 , ""},
                {"_TopOtasiningIsmi"        , ""},
                {"_TopMillati"              , ""},
                {"_TopKimTomonidanBerilgan" , ""},
                {"_TopJinsi"                , ""}
            };

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("http://94.158.53.231:5200/xml.xml");

            XmlElement Uz_Passport_MRZxRoot = xmlDoc.DocumentElement;

            var passportItems = Uz_Passport_MRZxRoot.FirstChild;
            foreach (XmlNode item in passportItems)
            {
                dict[item.Name] = item.InnerText;
            }
        }

        public void LoadScanJpg()
        {
            
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData("http://94.158.53.231:5200/1.jpg");

            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            var a = 7;

        }
        
    }
}
