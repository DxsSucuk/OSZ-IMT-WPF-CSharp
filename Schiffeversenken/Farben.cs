using System;

namespace Schiffeversenken
{
    public class Farben
    {
        public static void start()
        {
            Console.ResetColor();
            int wert;
            Console.WriteLine("Bitte geben einen Wert zwischen 1 und 5 an.");
            wert = Convert.ToInt32(Console.ReadLine());

            switch (wert)
            {
                case 1:
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  ");
                    break;
                }

                case 2:
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("  ");
                    Console.Write(" ");
                    break;
                }

                case 3:
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("  "); 
                    Console.Write("  "); 
                    Console.Write("  "); 
                    break;
                }

                case 4:
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("  "); 
                    Console.Write("  "); 
                    Console.Write("  "); 
                    Console.Write("  "); 
                    break;
                }

                case 5:
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  "); 
                    Console.Write("  "); 
                    Console.Write("  "); 
                    Console.Write("  "); 
                    Console.Write("  "); 
                    break;
                }

                default:
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
            }
            
            Mini.start();
        }
    }
}