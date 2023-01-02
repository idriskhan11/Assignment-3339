using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ArrayAssignment
    {
        static void Main(string[] args)
        {


            //Write a function that takes an array of numbers and it should display the Odd and Even numbers
            int[] values = { 1, 5, 3, 9, 8, 24, 25, 33, 21, 44 };

            foreach (var result in values)
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine(result + " is a Even Value");
                }
                else
                {
                    Console.WriteLine(result + " is a Odd Value");
                }
            }
        }
    }
}


