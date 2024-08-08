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
                        new XAttribute("class", "com.fr.report.worksheet.WorkSheet"),
                        new XAttribute("name", "sheet1"),
                        new XElement("ReportPageAttr",
                            new XElement("HR"),
                            new XElement("FR"),
                            new XElement("HC"),
                            new XElement("FC")
                        ),
                        new XElement("ColumnPrivilegeControl"),
                        new XElement("RowPrivilegeControl"),
                        new XElement("RowHeight",
                            new XAttribute("defaultValue", "723900"),
                            new XCData("723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900,723900")
                        ),
                        new XElement("ColumnWidth",
                            new XAttribute("defaultValue", "2743200"),
                            new XCData("2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200")
                        ),
                        new XElement("ReportAttrSet",
                            new XElement("ReportSettings",
                                new XAttribute("headerHeight", "0"),
                                new XAttribute("footerHeight", "0"),
                                new XElement("PaperSetting"),
                                new XElement("Background",
                                    new XAttribute("name", "ColorBackground"),
                                    new XAttribute("color", "-1")
                                )
                            )
                        ),
                        new XElement("PrivilegeControl")
                    ),
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
                    ),
                    new XElement("DesignerVersion",
                        new XAttribute("DesignerVersion", "KAA")
                    ),
                    new XElement("PreviewType",
                        new XAttribute("PreviewType", "0")
                    ),
                    new XElement("TemplateCloudInfoAttrMark",
                        new XAttribute("class", "com.fr.plugin.cloud.analytics.attr.TemplateInfoAttrMark"),
                        new XAttribute("pluginID", "com.fr.plugin.cloud.analytics.v10"),
                        new XAttribute("plugin-version", "2.14.0.20230222"),
                        new XElement("TemplateCloudInfoAttrMark",
                            new XAttribute("createTime", "1722906456857")
                        )
                    ),
                    new XElement("TemplateIdAttMark",
                        new XAttribute("class", "com.fr.base.iofile.attr.TemplateIdAttrMark"),
                        new XElement("TemplateIdAttMark",
                            new XAttribute("TemplateId", "b9649a92-fdb6-43ec-8976-d553bcdf972c")
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