using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class check
    {
        static int count = 0;
      public  static bool isPrimeNumber(int num)

        {
            if (num == 0 || num == 1)
            {
                return false;

            }
            else
            {
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        count++;

                    }
                }
                if (count == 0)
                {
                    return true;
                }
            }
            return false;
        }



    }



        class PrimeNumber22
        {
            static void Main(string[] args)
            {
            do
            {
                int a = Utilities.GetNumber("Enter the number to check");
                Console.WriteLine(check.isPrimeNumber(a));
            }
            while (true);

            }
        }
}
