using System;
using System.Data;
using System.Data.SqlClient;

namespace CompanyDataApp
{
    public class EmployeeCounter
    {
        static string connectionString = "Server=ABHINAV\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;";

        public static void Run()
        {
            Console.Write("Enter Department ID to count employees: ");
            int deptId = Convert.ToInt32(Console.ReadLine());

            GetEmployeeCountByDepartment(deptId);
        }

        private static void GetEmployeeCountByDepartment(int departmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetEmployeeCountByDepartment", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                try
                {
                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    Console.WriteLine($"Total employees in Department {departmentId}: {count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
