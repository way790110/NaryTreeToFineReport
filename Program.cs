using System;
using System.Xml.Linq;
using XmlGeneration;
using XmlPartGeneration;
using TreeStructure;

class Program
{
    static void Main()
    {
        // 调用 XmlPartGenerator 生成 XML 部分
        XDocument xmlMain = XmlGenerator.GenerateXml();

        XElement xmlRoot = new XElement("CellElementList");

        // List<TreeNode> nodes = new List<TreeNode>
        // {
        //     new TreeNode("Root", null), // 根節點
        //     new TreeNode("Child1", "Root"),
        //     new TreeNode("Child2", "Root"),
        //     new TreeNode("Child3", "Root"),
        //     new TreeNode("Child4", "Root"),
        //     new TreeNode("Grandchild1", "Child4"),
        //     new TreeNode("Grandchild2", "Child4"),
        //     new TreeNode("Grandchild3", "Child4"),
        //     new TreeNode("Grandchild4", "Child2"),
        //     new TreeNode("Grandchild5", "Child2"),
        //     new TreeNode("Grandchild6", "Child3"),
        //     new TreeNode("GGrandchild1", "Grandchild1"),
        //     new TreeNode("GGrandchild2", "Grandchild1"),
        //     new TreeNode("GGrandchild3", "Grandchild1"),
        // };

        List<TreeNode> nodes = new List<TreeNode>
        {

            new TreeNode("生物界 (Biota)", null),
            new TreeNode("動物界 (Animalia)", "生物界 (Biota)"),
            new TreeNode("脊索動物門 (Chordata)", "動物界 (Animalia)"),
            new TreeNode("哺乳綱 (Mammalia)", "脊索動物門 (Chordata)"),
            new TreeNode("靈長目 (Primates)", "哺乳綱 (Mammalia)"),
            new TreeNode("人科 (Hominidae)", "靈長目 (Primates)"),
            new TreeNode("人屬 (Homo)", "人科 (Hominidae)"),
            new TreeNode("人類 (Homo sapiens)", "人屬 (Homo)"),
            new TreeNode("食肉目 (Carnivora)", "哺乳綱 (Mammalia)"),
            new TreeNode("貓科 (Felidae)", "食肉目 (Carnivora)"),
            new TreeNode("貓屬 (Felis)", "貓科 (Felidae)"),
            new TreeNode("家貓 (Felis catus)", "貓屬 (Felis)"),
            new TreeNode("長鼻目 (Proboscidea)", "哺乳綱 (Mammalia)"),
            new TreeNode("象科 (Elephantidae)", "長鼻目 (Proboscidea)"),
            new TreeNode("象屬 (Elephas)", "象科 (Elephantidae)"),
            new TreeNode("亞洲象 (Elephas maximus)", "象屬 (Elephas)"),
            new TreeNode("鳥綱 (Aves)", "脊索動物門 (Chordata)"),
            new TreeNode("雁形目 (Anseriformes)", "鳥綱 (Aves)"),
            new TreeNode("鴨科 (Anatidae)", "雁形目 (Anseriformes)"),
            new TreeNode("鴨屬 (Anas)", "鴨科 (Anatidae)"),
            new TreeNode("綠頭鴨 (Anas platyrhynchos)", "鴨屬 (Anas)"),
            new TreeNode("兩棲綱 (Amphibia)", "脊索動物門 (Chordata)"),
            new TreeNode("無尾目 (Anura)", "兩棲綱 (Amphibia)"),
            new TreeNode("樹蛙科 (Hylidae)", "無尾目 (Anura)"),
            new TreeNode("樹蛙屬 (Agalychnis)", "樹蛙科 (Hylidae)"),
            new TreeNode("紅眼樹蛙 (Agalychnis callidryas)", "樹蛙屬 (Agalychnis)"),
            new TreeNode("硬骨魚綱 (Actinopterygii)", "脊索動物門 (Chordata)"),
            new TreeNode("鯛形目 (Perciformes)", "硬骨魚綱 (Actinopterygii)"),
            new TreeNode("海馬科 (Syngnathidae)", "鯛形目 (Perciformes)"),
            new TreeNode("海馬屬 (Hippocampus)", "海馬科 (Syngnathidae)"),
            new TreeNode("海馬 (Hippocampus kuda)", "海馬屬 (Hippocampus)"),
            new TreeNode("膜翅目 (Hymenoptera)", "昆蟲綱 (Insecta)"),
            new TreeNode("蜜蜂科 (Apidae)", "膜翅目 (Hymenoptera)"),
            new TreeNode("蜜蜂屬 (Apis)", "蜜蜂科 (Apidae)"),
            new TreeNode("蜜蜂 (Apis mellifera)", "蜜蜂屬 (Apis)"),
            new TreeNode("甲殼綱 (Malacostraca)", "動物界 (Animalia)"),
            new TreeNode("十足目 (Decapoda)", "甲殼綱 (Malacostraca)"),
            new TreeNode("帝王蟹科 (Lithodidae)", "十足目 (Decapoda)"),
            new TreeNode("帝王蟹屬 (Paralithodes)", "帝王蟹科 (Lithodidae)"),
            new TreeNode("帝王蟹 (Paralithodes camtschaticus)", "帝王蟹屬 (Paralithodes)"),
            new TreeNode("軟體動物門 (Mollusca)", "動物界 (Animalia)"),
            new TreeNode("腹足綱 (Gastropoda)", "軟體動物門 (Mollusca)"),
            new TreeNode("蝸牛科 (Helicidae)", "腹足綱 (Gastropoda)"),
            new TreeNode("花蝸牛屬 (Cornu)", "蝸牛科 (Helicidae)"),
            new TreeNode("花蝸牛 (Cornu aspersum)", "花蝸牛屬 (Cornu)"),
            new TreeNode("環形動物門 (Annelida)", "動物界 (Animalia)"),
            new TreeNode("多毛綱 (Polychaeta)", "環形動物門 (Annelida)"),
            new TreeNode("寡毛綱 (Oligochaeta)", "環形動物門 (Annelida)"),
            new TreeNode("土壤蟲科 (Lumbricidae)", "寡毛綱 (Oligochaeta)"),
            new TreeNode("美洲蠕蟲 (Lumbricus terrestris)", "土壤蟲科 (Lumbricidae)"),
            new TreeNode("被子植物門 (Angiosperms)", "植物界 (Plantae)"),
            new TreeNode("雙子葉植物綱 (Dicotyledonae)", "被子植物門 (Angiosperms)"),
            new TreeNode("芸香目 (Sapindales)", "雙子葉植物綱 (Dicotyledonae)"),
            new TreeNode("芸香科 (Rutaceae)", "芸香目 (Sapindales)"),
            new TreeNode("橙屬 (Citrus)", "芸香科 (Rutaceae)"),
            new TreeNode("紅橙 (Citrus sinensis)", "橙屬 (Citrus)"),
            new TreeNode("單子葉植物綱 (Monocotyledonae)", "被子植物門 (Angiosperms)"),
            new TreeNode("禾本目 (Poales)", "單子葉植物綱 (Monocotyledonae)"),
            new TreeNode("禾本科 (Poaceae)", "禾本目 (Poales)"),
            new TreeNode("稻屬 (Oryza)", "禾本科 (Poaceae)"),
            new TreeNode("稻 (Oryza sativa)", "稻屬 (Oryza)"),
            new TreeNode("蕨類植物門 (Pteridophyta)", "植物界 (Plantae)"),
            new TreeNode("鐵角蕨科 (Pteridaceae)", "蕨類植物門 (Pteridophyta)"),
            new TreeNode("鐵角蕨屬 (Pteris)", "鐵角蕨科 (Pteridaceae)"),
            new TreeNode("鐵角蕨 (Pteris vittata)", "鐵角蕨屬 (Pteris)"),
            new TreeNode("蘭屬 (Orchis)", "蘭科 (Orchidaceae)"),
            new TreeNode("斑點蘭 (Orchis maculata)", "蘭屬 (Orchis)"),
            new TreeNode("紅花龍膽科 (Gentianaceae)", "雙子葉植物綱 (Dicotyledonae)"),
            new TreeNode("龍膽屬 (Gentiana)", "紅花龍膽科 (Gentianaceae)"),
            new TreeNode("美洲龍膽 (Gentiana calycosa)", "龍膽屬 (Gentiana)"),
            new TreeNode("苔蘚植物門 (Bryophyta)", "植物界 (Plantae)"),
            new TreeNode("球果苔科 (Sphagnaceae)", "苔蘚植物門 (Bryophyta)"),
            new TreeNode("球果苔屬 (Sphagnum)", "球果苔科 (Sphagnaceae)"),
            new TreeNode("球果苔 (Sphagnum palustre)", "球果苔屬 (Sphagnum)"),
            new TreeNode("藻類門 (Algae)", "植物界 (Plantae)"),
            new TreeNode("綠藻綱 (Chlorophyceae)", "藻類門 (Algae)"),
            new TreeNode("克雷蘭藻屬 (Chlorella)", "綠藻綱 (Chlorophyceae)"),
            new TreeNode("克雷蘭藻 (Chlorella vulgaris)", "克雷蘭藻屬 (Chlorella)"),
            new TreeNode("紅藻門 (Rhodophyta)", "植物界 (Plantae)"),
            new TreeNode("紫菜科 (Bangia)", "紅藻門 (Rhodophyta)"),
            new TreeNode("紫菜 (Bangia atropurpurea)", "紫菜科 (Bangia)"),
            new TreeNode("海藻門 (Phaeophyceae)", "植物界 (Plantae)"),
            new TreeNode("褐藻綱 (Phaeophyceae)", "海藻門 (Phaeophyceae)"),
            new TreeNode("昆布科 (Laminariales)", "褐藻綱 (Phaeophyceae)"),
            new TreeNode("昆布屬 (Laminaria)", "昆布科 (Laminariales)"),
            new TreeNode("昆布 (Laminaria japonica)", "昆布屬 (Laminaria)"),
            new TreeNode("原生生物界 (Protista)", "生物界 (Biota)"),
            new TreeNode("變形蟲門 (Amoebozoa)", "原生生物界 (Protista)"),
            new TreeNode("變形蟲科 (Amoebidae)", "變形蟲門 (Amoebozoa)"),
            new TreeNode("變形蟲屬 (Amoeba)", "變形蟲科 (Amoebidae)"),
            new TreeNode("變形蟲 (Amoeba proteus)", "變形蟲屬 (Amoeba)"),
            new TreeNode("纖毛蟲門 (Ciliophora)", "原生生物界 (Protista)"),
            new TreeNode("草履蟲科 (Parameciidae)", "纖毛蟲門 (Ciliophora)"),
            new TreeNode("草履蟲屬 (Paramecium)", "草履蟲科 (Parameciidae)"),
            new TreeNode("草履蟲 (Paramecium caudatum)", "草履蟲屬 (Paramecium)"),
            new TreeNode("藍藻屬 (Cyanobium)", "藍藻科 (Cyanobacteriaceae)"),
            new TreeNode("藍藻 (Cyanobium gracile)", "藍藻屬 (Cyanobium)"),
            new TreeNode("真菌界 (Fungi)", "生物界 (Biota)"),
            new TreeNode("擔子菌門 (Basidiomycota)", "真菌界 (Fungi)"),
            new TreeNode("菇科 (Agaricaceae)", "擔子菌門 (Basidiomycota)"),
            new TreeNode("蘑菇屬 (Agaricus)", "菇科 (Agaricaceae)"),
            new TreeNode("普通蘑菇 (Agaricus bisporus)", "蘑菇屬 (Agaricus)"),
            new TreeNode("子囊菌門 (Ascomycota)", "真菌界 (Fungi)"),
            new TreeNode("酵母菌科 (Saccharomycetaceae)", "子囊菌門 (Ascomycota)"),
            new TreeNode("酵母菌屬 (Saccharomyces)", "酵母菌科 (Saccharomycetaceae)"),
            new TreeNode("啤酒酵母 (Saccharomyces cerevisiae)", "酵母菌屬 (Saccharomyces)"),
            new TreeNode("革蘚門 (Lichenes)", "真菌界 (Fungi)"),
            new TreeNode("革蘚科 (Parmeliaceae)", "革蘚門 (Lichenes)"),
            new TreeNode("革蘚屬 (Parmelia)", "革蘚科 (Parmeliaceae)"),
            new TreeNode("牛皮革蘚 (Parmela sulcata)", "革蘚屬 (Parmelia)"),
            new TreeNode("腔腸動物門 (Cnidaria)", "動物界 (Animalia)"),
            new TreeNode("水母綱 (Scyphozoa)", "腔腸動物門 (Cnidaria)"),
            new TreeNode("鐘水母科 (Aurelia)", "水母綱 (Scyphozoa)"),
            new TreeNode("鐘水母 (Aurelia aurita)", "鐘水母科 (Aurelia)"),
            new TreeNode("環節動物門 (Annelida)", "動物界 (Animalia)"),
            new TreeNode("環毛蟲科 (Syllidae)", "多毛綱 (Polychaeta)"),
            new TreeNode("環毛蟲屬 (Syllis)", "環毛蟲科 (Syllidae)"),
            new TreeNode("環毛蟲 (Syllis sp.)", "環毛蟲屬 (Syllis)"),
            new TreeNode("植物界 (Plantae)", "生物界 (Biota)"),
            new TreeNode("裸子植物門 (Gymnosperms)", "植物界 (Plantae)"),
            new TreeNode("松科 (Pinaceae)", "裸子植物門 (Gymnosperms)"),
            new TreeNode("松屬 (Pinus)", "松科 (Pinaceae)"),
            new TreeNode("紅松 (Pinus densiflora)", "松屬 (Pinus)"),
            new TreeNode("豆科 (Fabaceae)", "雙子葉植物綱 (Dicotyledonae)"),
            new TreeNode("豆屬 (Glycine)", "豆科 (Fabaceae)"),
            new TreeNode("大豆 (Glycine max)", "豆屬 (Glycine)"),
            new TreeNode("蘭科 (Orchidaceae)", "被子植物門 (Angiosperms)"),
            new TreeNode("石斑蘭屬 (Cattleya)", "蘭科 (Orchidaceae)"),
            new TreeNode("貓頭蘭 (Cattleya labiata)", "石斑蘭屬 (Cattleya)"),
            new TreeNode("藍藻門 (Cyanobacteria)", "原生生物界 (Protista)"),
            new TreeNode("藍藻科 (Cyanobacteriaceae)", "藍藻門 (Cyanobacteria)"),
            new TreeNode("藍藻屬 (Anabaena)", "藍藻科 (Cyanobacteriaceae)"),
            new TreeNode("藍藻 (Anabaena cylindrica)", "藍藻屬 (Anabaena)"),
            new TreeNode("節肢動物門 (Arthropoda)", "動物界 (Animalia)"),
            new TreeNode("昆蟲綱 (Insecta)", "節肢動物門 (Arthropoda)"),
            new TreeNode("蝴蝶目 (Lepidoptera)", "昆蟲綱 (Insecta)"),
            new TreeNode("蛾科 (Noctuidae)", "蝴蝶目 (Lepidoptera)"),
            new TreeNode("夜蛾屬 (Spodoptera)", "蛾科 (Noctuidae)"),
            new TreeNode("軍隊蠋 (Spodoptera litura)", "夜蛾屬 (Spodoptera)"),
            new TreeNode("蛛形綱 (Arachnida)", "節肢動物門 (Arthropoda)"),
            new TreeNode("蠍科 (Scorpionidae)", "蛛形綱 (Arachnida)"),
            new TreeNode("帝蠍屬 (Pandinus)", "蠍科 (Scorpionidae)"),
            new TreeNode("帝蠍 (Pandinus imperator)", "帝蠍屬 (Pandinus)"),
            new TreeNode("圓形動物門 (Rotifera)", "動物界 (Animalia)"),
            new TreeNode("圓形動物綱 (Monogononta)", "圓形動物門 (Rotifera)"),
            new TreeNode("短旋齒目 (Ploima)", "圓形動物綱 (Monogononta)"),
            new TreeNode("短旋齒科 (Brachionidae)", "短旋齒目 (Ploima)"),
            new TreeNode("短旋齒屬 (Brachionus)", "短旋齒科 (Brachionidae)"),
            new TreeNode("短旋齒 (Brachionus plicatilis)", "短旋齒屬 (Brachionus)"),
        };


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

        XElement reportElement = xmlMain.Root.Element("Report");
        reportElement.Add(xmlRoot);

        // XmlGenerator.DisplayXml(xmlMain);
        XmlGenerator.SaveXmlToFile(xmlMain, "output.cpt");
    }   
}
