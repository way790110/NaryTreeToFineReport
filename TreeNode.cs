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
            List<bool> indent = new List<bool>();
            xmlRoot = TreePrinter.PrintTreeInFineReport(xmlRoot, root, indent, true, 0, currentWidth, true, nodeDict);
            xmlRoot = TreePrinter.PrintTreeInCommandLine(xmlRoot, root, indent, true, 0, currentWidth, true, nodeDict);

            return xmlRoot;
        }

        
        public static XElement PrintTreeInFineReport(XElement element, TreeNode node, List<bool> indent, bool isLast, int depth, int[] currentWidth, bool isFirstInLevel, Dictionary<string, TreeNode> nodeDict)
        {
            int X_SPACE = 3;
            int X_START = 1;
            int Y_SPACE = 4;
            int Y_START = 1;

            if (node.Id == "_ROOT_") return element;

            // 確認當前節點的父節點是否只有一個子節點
            string parentId = node.ParentId;
            bool hasSingleChild = false;

            if (parentId != "_ROOT_" && nodeDict.ContainsKey(parentId))
            {
                hasSingleChild = nodeDict[parentId].Children.Count == 1;
            }

            if (depth == 0)
            {
                XmlGenerator.CreateRootCell(element, node.Id, "text2", X_START, Y_START);
            }

            else
            {
                if (isFirstInLevel)
                {
                    if (depth != 0 && isFirstInLevel && hasSingleChild)
                    {
                        XmlGenerator.AddOneNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                    else
                    {
                        XmlGenerator.AddFirstNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                }
                else
                {
                    for (int i = 0; i < indent.Count; i++)
                    {
                        if (indent[i] == true){
                            XmlGenerator.AddLineNode(element, i * X_SPACE + X_START, (currentWidth[0] + 1) * Y_SPACE + Y_START);
                        }
                    }

                    currentWidth[0]++;

                    if (isLast)
                    {
                        XmlGenerator.AddLastNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                    else
                    {
                        XmlGenerator.AddMiddleNode(element, node.Id, "text2", "text3", depth * X_SPACE + X_START, currentWidth[0] * Y_SPACE + Y_START);
                    }
                }
            }

            List<bool> newIndent = new List<bool>();
            newIndent.AddRange(indent);
            newIndent.Add(!isLast);

            // 打印所有子節點
            for (int i = 0; i < node.Children.Count; i++)
            {
                PrintTreeInFineReport(element, node.Children[i], newIndent, i == node.Children.Count - 1, depth + 1, currentWidth, i == 0, nodeDict);
            }

            return element;
        }

        
        public static XElement PrintTreeInCommandLine(XElement element, TreeNode node, List<bool> indent, bool isLast, int depth, int[] currentWidth, bool isFirstInLevel, Dictionary<string, TreeNode> nodeDict)
        {
            if (node.Id == "_ROOT_") return element;

            foreach (bool value in indent)
            {
                if (value)
                {
                    // Code to execute if the value is false
                    Console.Write("│   ");
                }
                else
                {
                    // Code to execute if the value is true
                    Console.Write("    ");
                }
                
            }
            
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
            }

            else
            {
                if (isFirstInLevel)
                {
                    if (depth != 0 && isFirstInLevel && hasSingleChild)
                    {
                        Console.Write("┗━━━ ");
                    }
                    else
                    {
                        Console.Write("╞══ ");
                    }
                }
                else
                {
                    for (int i = 0; i < indent.Count; i++)
                    {
                        if (indent[i] == true){
                        }
                    }

                    currentWidth[0]++;

                    if (isLast)
                    {
                        Console.Write("└── ");
                    }
                    else
                    {
                        Console.Write("├── ");
                    }
                }
            }
            Console.WriteLine(node.Id);
            
            List<bool> newIndent = new List<bool>();
            newIndent.AddRange(indent);
            newIndent.Add(!isLast);

            // 打印所有子節點
            for (int i = 0; i < node.Children.Count; i++)
            {
                PrintTreeInCommandLine(element, node.Children[i], newIndent, i == node.Children.Count - 1, depth + 1, currentWidth, i == 0, nodeDict);
            }

            return element;
        }
    }
}