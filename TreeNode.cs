using System.Xml.Linq;
using XmlGeneration;
using System;
using System.Collections.Generic;

namespace TreeStructure
{
    public class TreeNode
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string id, string parentId)
        {
            Id = id;
            ParentId = parentId;
            Children = new List<TreeNode>();
        }
    }

    
    public static class TreePrinter
    {
        public static XElement GenerateCellElementList(List<TreeNode> nodes)
        {
            XElement xmlRoot = new XElement("CellElementList");
                // 建立字典以便快速查找節點
            Dictionary<string, TreeNode> nodeDict = nodes.ToDictionary(n => n.Id);

            foreach (var node in nodes)
            {
                if (node.ParentId == "_ROOT_")
                {
                    continue; // 跳過根節點，因為它沒有父節點
                }
                if (nodeDict.ContainsKey(node.ParentId))
                {
                    nodeDict[node.ParentId].Children.Add(node);
                }
            }

            TreeNode root = nodeDict.Values.FirstOrDefault(n => n.ParentId == "_ROOT_")!;

            // 打印樹狀結構，包括根節點
            int[] currentWidth = new int[] { 0 }; // 用於記錄每層的行號
            xmlRoot = TreePrinter.PrintTree(xmlRoot, root, "", true, 0, currentWidth, true, nodeDict);

            return xmlRoot;
        }

        
        public static XElement PrintTree(XElement element, TreeNode node, string indent, bool isLast, int depth, int[] currentWidth, bool isFirstInLevel, Dictionary<string, TreeNode> nodeDict)
        {
            int X_SPACE = 3;
            int X_START = 1;
            int Y_SPACE = 4;
            int Y_START = 1;

            if (node.Id == "_ROOT_") return element;

            // 打印當前節點及其深度和寬度
            Console.Write(indent);
            
            // 確認當前節點的父節點是否只有一個子節點
            string parentId = node.ParentId;
            bool hasSingleChild = false;
            if (parentId != "_ROOT_" && nodeDict.ContainsKey(parentId))
            {
                hasSingleChild = nodeDict[parentId].Children.Count == 1;
            }

            if (depth == 0)
            {
                Console.Write("➽ ");
                XmlGenerator.CreateRootCell(element, node.Id, "text2", X_START, Y_START);
            }

            else
            {
                if (isFirstInLevel)
                {
                    if (depth != 0 && isFirstInLevel && hasSingleChild)
                    {
                        Console.Write("┗━━━ ");
                        XmlGenerator.AddOneNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                    else
                    {
                        Console.Write("╞══ ");
                        XmlGenerator.AddFirstNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                }
                else
                {
                    for (int i = 0,  j = 0; i < indent.Length; i+=4, j += 1)
                    {
                        if (indent[i] == '│')
                        {
                            XmlGenerator.AddLineNode(element, j * X_SPACE + X_START, (currentWidth[0] + 1) * Y_SPACE + Y_START);
                        }
                    }
                    if (isLast)
                    {
                        Console.Write("└── ");
                        currentWidth[0]++;
                        XmlGenerator.AddLastNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                    else
                    {
                        Console.Write("├── ");
                        currentWidth[0]++;
                        XmlGenerator.AddMiddleNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                }
            }
            Console.WriteLine(node.Id);
            // Console.WriteLine($" (Depth: {depth * 3 + 1}, Width: {currentWidth[0] * 4 + 1})");  // 打印節點後換行並顯示深度和寬度
            
            string newIndent = isLast ? indent + "    " : indent + "│   ";

            // 打印所有子節點
            for (int i = 0; i < node.Children.Count; i++)
            {
                PrintTree(element, node.Children[i], newIndent, i == node.Children.Count - 1, depth + 1, currentWidth, i == 0, nodeDict);
            }

            return element;
        }
    }
}