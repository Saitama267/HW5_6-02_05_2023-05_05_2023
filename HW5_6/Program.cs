using System;

namespace HW5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;
            while (true)
            {
                Console.WriteLine("\tMenu");
                Console.WriteLine("--------------------");
                Console.WriteLine("1- ");
                Console.WriteLine("2- ");
                Console.WriteLine("3- ");
                Console.WriteLine("4- ");
                Console.WriteLine("0- ");
                Int32.TryParse(Console.ReadLine(), out menu);
                if (menu == 0)
                {
                    break;
                }
                else if (menu == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter text with digits");
                    
                }
                else if (menu == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter text with digits");
                   
                }
                else if (menu == 3)
                {
                    Console.Clear();
                   
                }
                else if (menu == 4)
                {
                    Console.Clear();
                   
                }
            }

        }
    }
}
