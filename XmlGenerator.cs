using System;
using System.Text;
using System.Xml.Linq;

namespace XmlGeneration
{
    public class XmlGenerator
    {
        public static XDocument GenerateXml()
        {
            return new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement("WorkBook",
                    new XAttribute("xmlVersion", "20211223"),
                    new XAttribute("releaseVersion", "10.0.0"),
                    new XElement("Report",
                        new XAttribute("class", "com.fr.report.worksheet.WorkSheet"))
                )
            );
        }


        public static void SaveXmlToFile(XDocument xmlDoc, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
            {
                xmlDoc.Save(writer);
            }
        }

        public static void DisplayXml(XDocument xmlDoc)
        {
            string xmlOutput = xmlDoc.ToString();
            Console.WriteLine(xmlOutput);
        }

    }
}