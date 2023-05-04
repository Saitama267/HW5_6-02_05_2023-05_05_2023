using HW5_6.Models;
using Microsoft.Extensions.Configuration;
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
                _connectString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HW_3;Trusted_Connection=True;Integrated Security=True";
                //_connectString = ReadSecret("HW_3");
            }
            catch
            {
                throw;
            }
        }
        public string ReadSecret(string secretName)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            return config[secretName];
            
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
                                        Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)} ");
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

        public void Insert(Order order)
        { 

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
                            Value = order.AnalysisId,
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
