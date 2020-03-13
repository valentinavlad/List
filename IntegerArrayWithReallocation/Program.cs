using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerArrayWithReallocation
{
    class Program
    {

        static void Main()
        {


            // Define some integers for a division operation.
            int[] values = { 10, 7 };
            foreach (var value in values)
            {
                try
                {
                    Console.WriteLine("{0} divided by 2 is {1}", value, DivideByTwo(value));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                    Console.WriteLine("e.Message " + e.Message);
                }
                Console.WriteLine();
            }
        }

        static int DivideByTwo(int num)
        {
            // If num is an odd number, throw an ArgumentException.
            if ((num & 1) == 1)
                throw new ArgumentException(String.Format($"{num} is not an even number"),"nuam");

            // num is even, return half of its value.
            return num / 2;
        }
    }
}
