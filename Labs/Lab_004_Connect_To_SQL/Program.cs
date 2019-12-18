using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Lab_004_Connect_To_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // @ means literally take whats in the following string.
            // I.e. No 'Escaping' of characters allowed.

            string connectionString = @"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                //READ FROM DATABASE

                using (var sqlCommand = new SqlCommand("SELECT * FROM Customers", connection))
                {
                    //Create a loop to read, iterate and pass data.

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while(reader.Read())
                    {
                        string CustomerID = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerID,-15}{ContactName}");
                    }
                }
            }
        }
    }
}
