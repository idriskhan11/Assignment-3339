using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Calculater
    {
        static void Main(string[] args)
        {

            bool value = true;
            while (value)
            {
                Console.WriteLine("enter the first value for calculation");

                int firstValue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the second value for calculation");
                int secondValue = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("Enter the operator +, -, * ,/");
                switch (Console.ReadLine())
                {
                    case "+":
                        Console.WriteLine("the sum of given values is " + (firstValue + secondValue));
                        break;

                    case "-":
                        Console.WriteLine("the difference of given values is " + (firstValue - secondValue));
                        break;

                    case "*":
                        Console.WriteLine("the product of given values is " + (firstValue * secondValue));
                        break;

                    case "/":
                        if (secondValue != 0)
                        {
                            Console.WriteLine("the division of given values is " + (firstValue / secondValue));
                        }
                        else
                        {
                            Console.WriteLine("Arithematic Exception");
                        }
                        break;

                    default:
                        Console.WriteLine("enter correct option");
                        break;


                }
                Console.WriteLine("<<<<>>>>");
                Console.WriteLine("enter 0 to Exit");
                Console.WriteLine("type any number to continue");
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 0)
                   value = false;
            }
            Console.WriteLine("<<<<>>>>>");
            Console.WriteLine("calculation terminated");
        }
    }
}

