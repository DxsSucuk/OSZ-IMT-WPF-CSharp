using System;

namespace Schiffeversenken
{
    public class Gelaende
    {
        public static void start()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("  ");
            
            Console.WriteLine();
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
            Console.Write("  ");
            Console.Write("  ");
            
            Console.WriteLine();
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
            
            Console.WriteLine();
            
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
            
            Console.WriteLine();
            Farben.start();
        }
    }
}