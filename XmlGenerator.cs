using System;
using System.Text;
using System.Xml.Linq;

namespace XmlGeneration
{
    public class XmlGenerator
    {
        public static XDocument GenerateXml()
        {
            XDocument xmlDoc = new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement("WorkBook",
                    new XAttribute("xmlVersion", "20211223"),
                    new XAttribute("releaseVersion", "10.0.0"),
                    new XElement("Report",
                        new XAttribute("class", "com.fr.report.worksheet.WorkSheet")),
                    new XElement("StyleList",
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "ColorBackground"),
                                new XAttribute("color", "-3342388")
                            ),
                            new XElement("Border",
                                new XElement("Top", new XAttribute("style", "1")),
                                new XElement("Bottom", new XAttribute("style", "1")),
                                new XElement("Left", new XAttribute("style", "1")),
                                new XElement("Right", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Top", new XAttribute("style", "1")),
                                new XElement("Bottom", new XAttribute("style", "1")),
                                new XElement("Left", new XAttribute("style", "1")),
                                new XElement("Right", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Top", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Right", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Bottom", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Left", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Left", new XAttribute("style", "1")),
                                new XElement("Top", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Right", new XAttribute("style", "1")),
                                new XElement("Top", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Right", new XAttribute("style", "1")),
                                new XElement("Bottom", new XAttribute("style", "1"))
                            )
                        ),
                        new XElement("Style",
                            new XAttribute("imageLayout", "1"),
                            new XElement("FRFont",
                                new XAttribute("name", "Microsoft JhengHei"),
                                new XAttribute("style", "0"),
                                new XAttribute("size", "72")
                            ),
                            new XElement("Background",
                                new XAttribute("name", "NullBackground")
                            ),
                            new XElement("Border",
                                new XElement("Left", new XAttribute("style", "1")),
                                new XElement("Bottom", new XAttribute("style", "1"))
                            )
                        )
                    )
                )
            );
            return xmlDoc;
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