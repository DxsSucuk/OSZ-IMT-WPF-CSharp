using System;

namespace Schiffeversenken
{
    class Eingabe
    {
        static void Main(string[] args)
        {
            int[] positions = requestPositions();
            Console.WriteLine("Danke, dass Sie " + positions[1] + " und " + positions[0] + " eingegeben haben.");
            Gelaende.start();
        }

        static int[] requestPositions()
        {
            int y, x;
            Console.WriteLine("Bitte geben Sie die Y-Kordinate ein.");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie die X-Kordinate ein.");
            x = Convert.ToInt32(Console.ReadLine());
            return new int[] { y, x };
        }
    }
}