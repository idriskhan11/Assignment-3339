using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ArrayDynamic

    {
        static void Main(string[] args)
        {
            bool cond = true;
            while (cond)
            {
                Console.WriteLine("enter the size of array you want to create");
                int count = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("enter the number to specify type of array you want to create");
                Console.WriteLine(" 1 for INT type\n 2 for string type \n 3 for double type");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            int[] intarr = new int[count];
                            Console.WriteLine("enter the values");
                            for (int i = 0; i < count; i++)
                            {
                                intarr[i] = Convert.ToInt32(Console.ReadLine());
                            }
                            Console.WriteLine("traversing the entered array ");
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine(intarr[i]);
                            }
                            break;
                        }

                    case "2":
                        string[] stringarr = new string[count];
                        Console.WriteLine("enter the values");
                        for (int i = 0; i < count; i++)
                        {
                            stringarr[i] = Console.ReadLine();
                        }
                        Console.WriteLine("traversing the entered array ");
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(stringarr[i]);
                        }
                        break;

                    case "3":
                        double[] doublearr = new double[count];
                        Console.WriteLine("enter the values");
                        for (int i = 0; i < count; i++)
                        {
                            doublearr[i] = Convert.ToDouble(Console.ReadLine());
                        }
                        Console.WriteLine("traversing the entered array ");
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(doublearr[i]);
                        }
                        break;




                    default:
                        Console.WriteLine("enter valid choice");
                        break;


                }
                Console.WriteLine("*********************************");
                Console.WriteLine("enter 0 to abort operation");
                Console.WriteLine("type any number to continue");
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 0)
                    cond = false;
            }
            Console.WriteLine("operation ended");

        }
    }
}
