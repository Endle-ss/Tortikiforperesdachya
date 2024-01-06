using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortiki
{
    public static class Classmenu
    {
        public static int shouuu(string[] options)
        {
            int option = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт:");
                Console.WriteLine(new string('*', 50));
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == option     )
                    {
                        Console.Write("-> ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    Console.WriteLine(options[i]);
                }
                Console.WriteLine(new string('*', 50));
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (option > 0)
                        {
                            option--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (option < options.Length - 1)
                        {
                            option++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return option;
                }
            }
        }
    }
}
