using System;
using System.IO;
using System.Text.Json;

using System.Data;
using Microsoft.Data.SqlClient; // 或者 System.Data.SqlClient，如果使用舊版套件

namespace SQLQuery
{
    public class Config
    {
        public string SERVER { get; set; }
        public string DATABASE { get; set; }
        public string USER { get; set; }
        public string PASSWORD { get; set; }
        public string AUTH { get; set; }
    }


    public class SqlQueryExecutor
    {
        private string _connectionString;

        public SqlQueryExecutor(string configPath)
        {
            // 讀取 JSON 配置文件
            Config config = LoadConfig(configPath);

            // 構建連接字符串
            _connectionString = $"Server={config.SERVER};Database={config.DATABASE};User Id={config.USER};Password={config.PASSWORD};";
        }

        private Config LoadConfig(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                Config config = JsonSerializer.Deserialize<Config>(jsonString);
                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                throw;
            }
        }

        public DataTable ExecuteQuery(DateTime dateValue, decimal actUsage)
        {
            string sqlQuery = @"
                SELECT TOP(10) * FROM TN_POWER_SYS_VALUE_DAY;
                ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@DateParam", dateValue);
                    command.Parameters.AddWithValue("@ActUsageParam", actUsage);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable resultTable = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(resultTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Query error: {ex.Message}");
                    }

                    return resultTable;
                }
            }
        }
    }
}
