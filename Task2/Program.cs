using System;
using Task2.DataBaseClasses;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = 2020;
            Console.WriteLine("What year you whant to see:");
            Int32.TryParse(Console.ReadLine(), out year);
            HW3DB hw3 = new HW3DB(year);
            hw3.DataSetInfo();

        }
    }
}
