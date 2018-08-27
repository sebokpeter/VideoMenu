using System;
using VideoMenu.Core.Entity;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.Core
{
    public class Utility
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

        public static Genre SelectGenre()
        {
            bool correctSelection = false;
            Genre g = Genre.Action;

            while (!correctSelection)
            {
                int i = 1;
                foreach (var item in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine("{0}. -  {1}", i, item.ToString());
                    i++;
                }

                int selection = Utility.ReadNumber() - 1;

                if (Enum.IsDefined(typeof(Genre), selection))
                {
                    g = (Genre)selection;
                    correctSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection!");
                }
            }
            return g;

        }
    }
}
