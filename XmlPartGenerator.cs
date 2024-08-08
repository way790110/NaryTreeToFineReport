using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using TreeStructure;

namespace XmlPartGeneration
{
    public class XmlPartGenerator
    {
        public static XElement GenerateCellElementList(List<TreeNode> nodes)
        {
            XElement xmlRoot = new XElement("CellElementList");
                // 建立字典以便快速查找節點
            Dictionary<string, TreeNode> nodeDict = nodes.ToDictionary(n => n.Id);

            foreach (var node in nodes)
            {
                if (node.ParentId == null)
                {
                    continue; // 跳過根節點，因為它沒有父節點
                }
                if (nodeDict.ContainsKey(node.ParentId))
                {
                    nodeDict[node.ParentId].Children.Add(node);
                }
            }

            TreeNode root = nodeDict.Values.FirstOrDefault(n => n.ParentId == null);

            // 打印樹狀結構，包括根節點
            int[] currentWidth = new int[] { 0 }; // 用於記錄每層的行號
            xmlRoot = TreePrinter.PrintTree(xmlRoot, root, "", true, 0, currentWidth, true, nodeDict);

            return xmlRoot;
        }

        public static XElement GenerateStyleList(List<TreeNode> nodes){
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

        public static void CreateRootCell(XElement root, string text1, string text2, int x, int y)
        {
            XElement cElement1 = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 0),
                new XElement("O", new XCData(text1)),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            XElement cElement2 = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y + 1),
                new XAttribute("s", 1),
                new XElement("O", new XCData(text2)),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement1);
            root.Add(cElement2);
        }


        public static void CreateNodeCell(XElement root, string text1, string text2, string text3, int x, int y)
        {
            CreateRootCell(root, text1, text2, x, y);

            XElement cElement1 = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y + 2),
                new XAttribute("s", 1),
                new XElement("O", new XCData(text3)),
                new XElement("PrivilegeControl"),
                new XElement("Expand")
            );

            root.Add(cElement1);
        }


        public static void LineTop(XElement root, int x, int y)
        {
            XElement cElement = new XElement("C",
                new XAttribute("c", x),
                new XAttribute("r", y),
                new XAttribute("s", 2),
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
                new XAttribute("s", 3),
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
                new XAttribute("s", 4),
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
                new XAttribute("s", 5),
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
                new XAttribute("s", 6),
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
                new XAttribute("s", 7),
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
                new XAttribute("s", 8),
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
                new XAttribute("s", 9),
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