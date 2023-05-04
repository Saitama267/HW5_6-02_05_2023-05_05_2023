using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.DataBaseClasses
{
    class HW3DB
    {
        private string _connectionString;

        private DataSet _dataSet;

        private SqlDataAdapter _adapterOrders;

        public HW3DB(int year)
        {
            try
            {
                _connectionString = ReadSecret("HW_3");
                _dataSet = new DataSet();

                _adapterOrders = new SqlDataAdapter($"SELECT ord_id,ord_datetime,ord_an FROM Orders WHERE YEAR(ord_datetime) = {year};", _connectionString);


                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_adapterOrders);

                _adapterOrders.Fill(_dataSet, "Orders");
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

        public void DataSetInfo()
        {


            foreach (DataTable table in _dataSet.Tables)
            {
                Console.WriteLine($"\n\t\t\t{table.TableName}");

                foreach (DataColumn column in table.Columns)
                {
                    Console.Write($"{column.Caption}\t\t");
                }
                Console.WriteLine("\n------------------------------------\n");

                foreach (DataRow row in table.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        Console.Write($"{item}\t\t");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    
    }
}