using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class stingReverse
    {
       
        
            static string reverseString(string input)
            {
                string[] arr = input.Split(' ');
                string output = "";

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    output += arr[i];
                    output += " ";

                }

                return output;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("enter the input to reverse");
                string input = Console.ReadLine();
                string output = reverseString(input);

                Console.WriteLine(output);
            }
        }
    }
 
   

