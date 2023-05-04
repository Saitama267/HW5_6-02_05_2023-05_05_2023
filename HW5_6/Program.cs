using HW5_6.DataBaseClasses;
using HW5_6.Models;
using System;

namespace HW5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            HW3DB hw3 = new HW3DB();
            int menu = 0;
            int year = DateTime.Now.Year, month = DateTime.Now.Month, day = DateTime.Now.Day;
            int analysisId = 1;
            while (true)
            {
                Console.WriteLine("\tMenu");
                Console.WriteLine("--------------------");
                Console.WriteLine("1- Select");
                Console.WriteLine("2- Insert");
                Console.WriteLine("3- Update");
                Console.WriteLine("4- Delete");
                Console.WriteLine("0- Exit");
                Int32.TryParse(Console.ReadLine(), out menu);
                if (menu == 0)
                {
                    break;
                }
                else if (menu == 1)
                {
                    Console.Clear();
                    try
                    {
                        hw3.SelectDB("SELECT Orders.ord_id,Orders.ord_datetime,Analysis.an_name,Analysis.an_price,Analysis.an_cost,Groups.gr_name,Groups.gr_temp" +
                                               " FROM Orders" +
                                               " JOIN Analysis ON Orders.ord_an = Analysis.an_id" +
                                               " JOIN Groups ON Analysis.an_group = Groups.gr_id" +
                                               " WHERE YEAR(ord_datetime) = 2020");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    
                   
                }
                else if (menu == 2)
                {
                    
                    Console.Clear();
                    Console.WriteLine("Enter the Year of order that you want to insert:");
                    Int32.TryParse(Console.ReadLine(), out year);
                    Console.WriteLine("Enter the Month of order that you want to insert:");
                    Int32.TryParse(Console.ReadLine(), out month);
                    Console.WriteLine("Enter the Day of order that you want to insert:");
                    Int32.TryParse(Console.ReadLine(), out day);
                    Console.WriteLine("Enter the AnalysisId(from 1 to 10) of order that you want to insert:");
                    Int32.TryParse(Console.ReadLine(), out analysisId);
                    if (analysisId<1 || analysisId>10)
                    {
                        analysisId = 1;
                    }
                    Order order = new Order(year,month,day, analysisId);

                    try
                    {
                        hw3.Insert(order);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menu == 3)
                {
                    
                    Console.WriteLine("Enter the Month of order that you whant to change:");
                    Int32.TryParse(Console.ReadLine(), out month);
                    Console.WriteLine("Enter the AnalysisId for order that you whant to change:");
                    Int32.TryParse(Console.ReadLine(), out analysisId);
                    
                    Console.Clear();
                    try
                    {
                        hw3.NonQueryDB($"UPDATE Orders SET ord_an='{analysisId}' WHERE MONTH(ord_datetime) = {month}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                }
                else if (menu == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the Month of order that you whant to change:");
                    Int32.TryParse(Console.ReadLine(), out month);
                    Console.Clear();

                    try
                    {
                        hw3.NonQueryDB($"DELETE FROM Orders WHERE MONTH(ord_datetime) = {month}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

        }
    }
}
