using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManager
{
    class Program
    {
        static string connectionString = "Server=ABHINAV\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== EMPLOYEE MANAGER =====");
                Console.WriteLine("1. Insert New Employee");
                Console.WriteLine("2. View Employees by Department");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertEmployeeFromUser();
                        break;
                    case "2":
                        ViewEmployeesFromUser();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void InsertEmployeeFromUser()
        {
            Console.WriteLine("\n--- Insert New Employee ---");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Department ID: ");
            int departmentId = int.Parse(Console.ReadLine());

            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("Join Date (yyyy-mm-dd): ");
            DateTime joinDate = DateTime.Parse(Console.ReadLine());

            InsertEmployee(firstName, lastName, departmentId, salary, joinDate);
        }

        static void ViewEmployeesFromUser()
        {
            Console.Write("\nEnter Department ID to view employees: ");
            int departmentId = int.Parse(Console.ReadLine());
            GetEmployeesByDepartment(departmentId);
        }

        static void InsertEmployee(string firstName, string lastName, int departmentId, decimal salary, DateTime joinDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.Parameters.AddWithValue("@JoinDate", joinDate);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Employee inserted successfully.");
            }
        }

        static void GetEmployeesByDepartment(int departmentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No employees found in this department.");
                }

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["EmployeeID"]}, " +
                                      $"Name: {reader["FirstName"]} {reader["LastName"]}, " +
                                      $"Salary: Rs{reader["Salary"]}, " +
                                      $"Joined: {Convert.ToDateTime(reader["JoinDate"]).ToShortDateString()}");
                }

                conn.Close();
            }
        }
    }
}
