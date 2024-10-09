using System;
using System.IO;
using System.Text.Json;

using System.Data;
using Microsoft.Data.SqlClient; // 或者 System.Data.SqlClient，如果使用舊版套件

namespace SQLQuery
{
    public class Config
    {
        public string SERVER { get; set; } = string.Empty;
        public string DATABASE { get; set; } = string.Empty;
        public string USER { get; set; } = string.Empty;
        public string PASSWORD { get; set; } = string.Empty;
        public bool ENCRYPT { get; set; } = true;
        public bool AUTH { get; set; } = true;
    }


    public class SqlQueryExecutor
    {
        private string connectionString;

        public SqlQueryExecutor(string configPath)
        {
            // 讀取 JSON 配置文件
            Config config = LoadConfig(configPath);

            // 構建連接字符串
            connectionString = string.Concat(
                $"Server={config.SERVER};",
                $"Database={config.DATABASE};",
                $"User Id={config.USER};",
                $"Password={config.PASSWORD};",
                $"Encrypt={config.ENCRYPT};",
                $"TrustServerCertificate={config.AUTH};"
            );
        }

        private Config LoadConfig(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                Config? config = JsonSerializer.Deserialize<Config>(jsonString);

                // Check if config is null after deserialization
                if (config == null)
                {
                    return new Config();
                }
                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                return new Config();
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable); // 將查詢結果填充到 DataTable 中
                    }
                }
            }

            return dataTable; // 返回查詢結果
        }
    }
}
