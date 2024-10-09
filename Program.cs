using System;
using System.Xml.Linq;
using XmlGeneration;
using TreeStructure;
using SQLQuery;
using System.Xml.Serialization;
using System.Data;

using System.Text.Json;
using Microsoft.Data.SqlClient;
using System.Data.Common; // 或者 System.Data.SqlClient，如果使用舊版套件

class Program
{
    static void Main()
    {
        string configPath = @"D:\c_sharp\source\repos\NaryTreeToFineReport\config\config_localhost.json";

        // 初始化 SqlQueryExecutor
        SqlQueryExecutor executor = new SqlQueryExecutor(configPath);

        string query = @"
            WITH SUM_VALUE AS (
                SELECT 
                    CN_EQUIP_ID,  
                    SUM(CN_TAG_VALUE) AS NODE_VALUE
                FROM 
                    TN_POWERBALANCE_SYS_VALUE_MONTH
                WHERE
                    YEAR(CN_DATE) = 2024
                GROUP BY 
                    CN_EQUIP_ID
            ),
            CALCULATE_RATIO AS (
                SELECT
                    eh.CN_SON,
                    te_child.CN_NAME AS CHILD_NAME,
                    sv_child.NODE_VALUE AS CHILD_VALUE,
                    CASE 
                        WHEN eh.CN_SON = 'PB-001' THEN '_ROOT_' 
                        ELSE eh.CN_PARENT 
                    END AS CN_PARENT,
                    te_parent.CN_NAME AS PARENT_NAME,
                    sv_parent.NODE_VALUE AS PARENT_VALUE,
                    CASE 
                        WHEN sv_parent.NODE_VALUE != 0 THEN sv_child.NODE_VALUE / sv_parent.NODE_VALUE
                        ELSE NULL
                    END AS RATIO
                FROM 
                    TN_SYS_GROUP_ENERGY_DECLARE
                LEFT JOIN 
                    TN_EQUIP_HIER eh ON TN_SYS_GROUP_ENERGY_DECLARE.CN_EQUIP_ID = eh.CN_SON
                LEFT JOIN 
                    SUM_VALUE sv_child ON eh.CN_SON = sv_child.CN_EQUIP_ID
                LEFT JOIN 
                    SUM_VALUE sv_parent ON eh.CN_PARENT = sv_parent.CN_EQUIP_ID
                LEFT JOIN
                    TN_EQUIPMENT te_child ON eh.CN_SON = te_child.CN_ID
                LEFT JOIN
                    TN_EQUIPMENT te_parent ON eh.CN_PARENT = te_parent.CN_ID
                WHERE 
                    TN_SYS_GROUP_ENERGY_DECLARE.CN_DECLARE_TYPE = 'PowerBalance'
            )
            SELECT * 
            FROM 
                CALCULATE_RATIO
            ORDER BY
                CN_PARENT, 
                CN_SON;
        ";

        // 執行查詢並獲取結果
        DataTable result = executor.ExecuteQuery(query);

        List<TreeNode> nodes = new List<TreeNode>();
        // 輸出結果
        foreach (DataRow row in result.Rows)
        {
            string childName = row.ItemArray[0]?.ToString() ?? "Unnamed";
            string parentName = row.ItemArray[3]?.ToString() ?? "NoParent";
            TreeNode node = new TreeNode(childName, parentName);
            nodes.Add(node);
        }
        
        // Generate the main XML document using the XmlGenerator class
        XDocument xmlMain = XmlGenerator.GenerateXml();
        XElement xmlRoot = xmlMain.Root!.Element("Report") ?? new XElement("Report");

        // Generate a list of cell elements and add it to the "Report" element in the main XML
        XElement cellElementList = TreePrinter.GenerateCellElementList(nodes) ?? new XElement("CellElementList");
        xmlRoot.Add(cellElementList);

        // Generate a list of styles and add it to the "Report" element in the main XML
        XElement styleList = XmlGenerator.GenerateStyleList()  ?? new XElement("StyleList");
        xmlRoot.Add(styleList);

        // Save the modified XML document to a file named "output.cpt"
        XmlGenerator.SaveXmlToFile(xmlMain, "output.cpt");
    }   
}