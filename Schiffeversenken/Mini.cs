using System;

namespace Schiffeversenken
{
    public class Mini
    {
        private static int variable;

        public static void start()
        {
            int tries = 0;
            Console.ResetColor();
            variable = new Random().Next(1, 3);

            choice:
            if (tries < 2)
            {
                Console.WriteLine("Errate die Zahl! (1-3)");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice > 3 || choice < 1)
                {
                    Console.WriteLine("Fehlerhafte eingabe!");
                    goto choice;
                }
                else
                {
                    if (choice == variable)
                    {
                        Console.WriteLine("Richtig erraten!");
                    }
                    else
                    {
                        Console.WriteLine("Falsch!");
                        tries++;
                        goto choice;
                    }
                }
            }
            else
            {
                Console.WriteLine("Leider verloren!");
            }
        }
    }
}