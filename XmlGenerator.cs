using System;
using System.Text;
using System.Xml.Linq;
using TreeStructure;

namespace XmlGeneration
{
    public class XmlGenerator
    {
        public static XDocument GenerateBasicXml()
        {
            return new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("WorkBook",
                    new XAttribute("xmlVersion", "20211223"),
                    new XAttribute("releaseVersion", "10.0.0"),
                    new XElement("TableDataMap"),
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

        public static XElement GenerateTableDataMap(string query)
        {
            return new XElement("TableDataMap",  // 根节点
                new XElement("TableData",
                    new XAttribute("name", "ds_balance"),
                    new XAttribute("class", "com.fr.data.impl.DBTableData"),
                    new XElement("Attributes",
                        new XAttribute("maxMemRowCount", "-1")
                    ),
                    new XElement("Connection",
                        new XAttribute("class", "com.fr.data.impl.NameDatabaseConnection"),
                        new XElement("DatabaseName",
                            new XCData("IntelligentService_TXC")  // CDATA 包含数据库名称
                        )
                    ),
                    new XElement("Query",
                        new XCData(query) // 使用输入的查询字符串
                    )
                )
            );
        }



        public static XElement GenerateStyleList()
        {
            return new XElement("StyleList",
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
                    new XElement("Format",
                        new XAttribute("class", "com.fr.base.CoreDecimalFormat"),
                        new XAttribute("roundingMode", "6"),
                        new XCData("#,##0") // Using CDATA for the format string
                    ),
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
                    new XElement("Format",
                        new XAttribute("class", "com.fr.base.CoreDecimalFormat"),
                        new XAttribute("roundingMode", "6"),
                        new XCData("#0.00%") // Using CDATA for the format string
                    ),
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
            );
        }

        public static void CreateRootCell(XElement root, string id, string test2, int x, int y)
        {
            XElement cElement1 = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 0),
                new XElement("O",
                    new XAttribute("t", "DSColumn"),
                    new XElement("Attributes",
                        new XAttribute("dsName", "ds_balance"),
                        new XAttribute("columnName", "CHILD_NAME")
                    ),
                    new XElement("Condition",
                        new XAttribute("class", "com.fr.data.condition.CommonCondition"),
                        new XElement("CNUMBER",
                            new XCData("0") // Using CDATA to include the number
                        ),
                        new XElement("CNAME",
                            new XCData("CN_SON") // Using CDATA to include the string
                        ),
                        new XElement("Compare",
                            new XAttribute("op", "0"),
                            new XElement("O",
                                new XCData(id) // Using CDATA to include the input parameter
                            )
                        )
                    ),
                    new XElement("Complex"), // Empty element
                    new XElement("RG",
                        new XAttribute("class", "com.fr.report.cell.cellattr.core.group.FunctionGrouper")
                    ),
                    new XElement("Result",
                        new XCData("$$$") // Using CDATA to include the string
                    ),
                    new XElement("Parameters")
                ),
                new XElement("PrivilegeControl"), // Empty element
                new XElement("Expand",
                    new XAttribute("leftParentDefault", "false"),
                    new XAttribute("upParentDefault", "false")
                )
            );

            XElement cElement2 = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y + 1),
                new XAttribute("s", 1),
                new XElement("O",
                    new XAttribute("t", "DSColumn"),
                    new XElement("Attributes",
                        new XAttribute("dsName", "ds_balance"),
                        new XAttribute("columnName", "CHILD_VALUE")
                    ),
                    new XElement("Condition",
                        new XAttribute("class", "com.fr.data.condition.CommonCondition"),
                        new XElement("CNUMBER",
                            new XCData("0") // Using CDATA to include the number
                        ),
                        new XElement("CNAME",
                            new XCData("CN_SON") // Using CDATA to include the string
                        ),
                        new XElement("Compare",
                            new XAttribute("op", "0"),
                            new XElement("O",
                                new XCData(id) // Using CDATA to include the input parameter
                            )
                        )
                    ),
                    new XElement("Complex"), // Empty element
                    new XElement("RG",
                        new XAttribute("class", "com.fr.report.cell.cellattr.core.group.FunctionGrouper")
                    ),
                    new XElement("Result",
                        new XCData("$$$") // Using CDATA to include the string
                    ),
                    new XElement("Parameters")
                ),
                new XElement("PrivilegeControl"), // Empty element
                new XElement("Expand",
                    new XAttribute("leftParentDefault", "false"),
                    new XAttribute("upParentDefault", "false")
                )
            );

            root.Add(cElement1);
            root.Add(cElement2);
        }


        public static void CreateNodeCell(XElement root, string id, string text2, string text3, int x, int y)
        {
            CreateRootCell(root, id, text2, x, y);

            XElement cElement1 = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y + 2),
                new XAttribute("s", 2),
                new XElement("O",
                    new XAttribute("t", "DSColumn"),
                    new XElement("Attributes",
                        new XAttribute("dsName", "ds_balance"),
                        new XAttribute("columnName", "RATIO")
                    ),
                    new XElement("Condition",
                        new XAttribute("class", "com.fr.data.condition.CommonCondition"),
                        new XElement("CNUMBER",
                            new XCData("0") // CDATA for CNUMBER
                        ),
                        new XElement("CNAME",
                            new XCData("CN_SON") // CDATA for CNAME
                        ),
                        new XElement("Compare",
                            new XAttribute("op", "0"),
                            new XElement("O",
                                new XCData(id) // Using input parameter
                            )
                        )
                    ),
                    new XElement("Complex"),
                    new XElement("RG",
                        new XAttribute("class", "com.fr.report.cell.cellattr.core.group.FunctionGrouper")
                    ),
                    new XElement("Result",
                        new XCData("$$$") // CDATA for Result
                    ),
                    new XElement("Parameters")
                ),
                new XElement("PrivilegeControl"),
                new XElement("Expand",
                    new XAttribute("leftParentDefault", "false"),
                    new XAttribute("upParentDefault", "false")
                )
            );

            root.Add(cElement1);
        }


        public static void LineTop(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 3),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void LineRight(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 4),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void LineBottom(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 5),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void LineLeft(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 6),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void CornerUpperLeft(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 7),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void CornerUpperRight(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 8),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void CornerLowerRight(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 9),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void CornerLowerLeft(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 10),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement);
        }


        public static void AddOneNode(XElement root, string text1, string text2, string text3, int x, int y)
        {
            CreateNodeCell(root, text1, text2, text3, x, y);
            LineBottom(root, x-1, y);
            LineBottom(root, x-2, y);
        }


        public static void AddFirstNode(XElement root, string text1, string text2, string text3, int x, int y)
        {
            CreateNodeCell(root, text1, text2, text3, x, y);
            CornerUpperLeft(root, x-1, y+1);
            LineTop(root, x-2, y+1);
            LineLeft(root, x-1, y+2);
            LineLeft(root, x-1, y+3);
        }


        public static void AddMiddleNode(XElement root, string text1, string text2, string text3, int x, int y)
        {
            CreateNodeCell(root, text1, text2, text3, x, y);
            CornerLowerLeft(root, x-1, y);
            LineLeft(root, x-1, y+1);
            LineLeft(root, x-1, y+2);
            LineLeft(root, x-1, y+3);
        }


        public static void AddLastNode(XElement root, string text1, string text2, string text3, int x, int y)
        {
            CreateNodeCell(root, text1, text2, text3, x, y);
            CornerLowerLeft(root, x-1, y);
        }


        public static void AddLineNode(XElement root, int x, int y)
        {
            LineLeft(root, x-1, y);
            LineLeft(root, x-1, y+1);
            LineLeft(root, x-1, y+2);
            LineLeft(root, x-1, y+3);
        }
    }
}