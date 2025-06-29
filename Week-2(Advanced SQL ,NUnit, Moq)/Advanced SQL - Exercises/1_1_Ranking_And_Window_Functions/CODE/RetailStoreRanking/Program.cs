using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=ABHINAV\\SQLEXPRESS;Database=RetailStoreDB;Trusted_Connection=True;";

            string query = @"
                WITH RankedProducts AS (
                    SELECT
                        ProductID,
                        ProductName,
                        Category,
                        Price,
                        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
                        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
                        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
                    FROM Products
                )
                SELECT *
                FROM RankedProducts
                WHERE RowNum <= 3 OR RankNum <= 3 OR DenseRankNum <= 3
                ORDER BY Category, Price DESC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("ProductID | ProductName      | Category    | Price   | RowNum | RankNum | DenseRank");

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ProductID"],-9} | {reader["ProductName"],-15} | {reader["Category"],-10} | {reader["Price"],-7} | {reader["RowNum"],-6} | {reader["RankNum"],-7} | {reader["DenseRankNum"]}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
            }
        }
    }
}