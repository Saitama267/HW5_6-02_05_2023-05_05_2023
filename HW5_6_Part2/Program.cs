using HW5_6_Part2.DataBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_6_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderTable order = new OrderTable();
            int menu = 0, id = 0;
            int year = DateTime.Now.Year, month = DateTime.Now.Month, day = DateTime.Now.Day;
            int analysisId = 1;
            while (true)
            {
                Console.WriteLine("\tMenu");
                Console.WriteLine("--------------------");
                Console.WriteLine("1- Show"); 
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
                    Console.Clear();
                    Console.WriteLine("Enter the Year of order that you want to insert:");
                    Int32.TryParse(Console.ReadLine(), out year);
                    try
                    {
                        order.Show(year);
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
                    if (analysisId < 1 || analysisId > 10)
                    {
                        analysisId = 1;
                    }
                    

                    try
                    {
                        order.OrderInsert(
                            new Orders
                            {
                                Ord_datetime = new DateTime(year,month,day),
                                Ord_an = analysisId
                            });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menu == 3)
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
                    Console.WriteLine("Enter the Id of order that you want to update:");
                    Int32.TryParse(Console.ReadLine(), out id);
                    if (analysisId < 1 || analysisId > 10)
                    {
                        analysisId = 1;
                    }

                    
                    try
                    {
                        order.OrderUpdate(id,
                             new Orders
                             {
                                 Ord_datetime = new DateTime(year, month, day),
                                 Ord_an = analysisId
                             });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (menu == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the Id of order that you want to delete:");
                    Int32.TryParse(Console.ReadLine(), out id);
                    Console.Clear();

                    try
                    {
                        order.OrderDelete(id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
