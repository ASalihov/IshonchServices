using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewTests
{
    public class XmlParser
    {
        public void LoadXmlDocument()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("http://94.158.53.231:5200/xml.xml");

            XmlElement Uz_Passport_MRZxRoot = xmlDoc.DocumentElement;

            var passportItems = Uz_Passport_MRZxRoot.FirstChild;
            foreach (XmlNode item in passportItems)
            {
                var a = item;
            }
        }
        
    }
}
