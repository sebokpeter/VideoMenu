using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu
{
    class Utility
    {
        public static int ReadNumber()
        {
            int a;

            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Please enter a number!");
            }

            return a;
        }
    }
}
