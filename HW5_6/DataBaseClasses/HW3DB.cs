using HW5_6.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_6.DataBaseClasses
{
    class HW3DB
    {
        private string _connectString;

        public HW3DB()
        {
            try
            {
                _connectString = ConfigurationManager.ConnectionStrings["HW_3"].ConnectionString;
            }
            catch
            {
                throw;
            }
        }

        public void SelectDB(string commandText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            do
                            {
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)}\t");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("\n----------------------------------------\n");

                            } while (reader.NextResult());
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void StudentInsert(Order order)
        {
            /* correct
            string name = textBox1.Text; // Jack
            string commandText = $"SELECT * FROM Students WHERE FirstName ='{name}'";
            SELECT * FROM Students WHERE FirstName ='Jack'*/

            /* incorrect
            string name = textBox1.Text; // Jack';DELETE FROM Students--
            string commandText = $"SELECT * FROM Students WHERE FirstName ='{name}'";
            SELECT * FROM Students WHERE FirstName ='Jack';DELETE FROM Students--'*/

            try
            {
                string text = $"INSERT INTO Orders VALUES(@OrderDate, @AnalysisId);";

                using (SqlConnection connection = new SqlConnection(_connectString))
                {
                    using (SqlCommand command = new SqlCommand(text, connection))
                    {
                        SqlParameter parameter = new SqlParameter
                        {
                            ParameterName = "@OrderDate",
                            Value = order.OrderDate,
                            SqlDbType = SqlDbType.DateTime,
                        };
                        command.Parameters.Add(parameter);

                        parameter = new SqlParameter
                        {
                            ParameterName = "@AnalysisId",
                            Value = order.AnalasisId,
                            SqlDbType = SqlDbType.Int,
 
                        };
                        command.Parameters.Add(parameter);

                        connection.Open();

                        if (command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Commands completed successfully!");
                        }
                        else
                        {
                            throw new Exception("...");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void NonQueryDB(string text)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectString))
                {
                    using (SqlCommand command = new SqlCommand(text, connection))
                    {
                        connection.Open();

                        if (command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Commands completed successfully!");
                        }
                        else
                        {
                            throw new Exception("...");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

       
        
    }
}
