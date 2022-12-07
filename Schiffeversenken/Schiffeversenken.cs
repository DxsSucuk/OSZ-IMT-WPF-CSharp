using System;
using System.Collections.Generic;
using System.Linq;

namespace Schiffeversenken
{
    public class Schiffeversenken
    {
        private static Player playerOne = new Player("test");

        public static void Main(String[] args)
        {
            ////AskForName();
            ////showCurrentMap();
            AskForShipPositions();
            showCurrentMap();
        }

        public static void AskForName()
        {
            Console.WriteLine("Wie heißt du?");
            String name = Console.ReadLine();
            playerOne = new Player(name);
        }

        public static void showCurrentMap()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (playerOne.Schiffe.Any(c => c.Positionen[0] == y && c.Positionen[1] == x))
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if (playerOne.Schiffe.Any(c =>
                                 c.Positionen[0] < y && y - c.Positionen[0] >= c.FixedSize && c.Positionen[2] == 4 && c.Positionen[1] == x)) // Unten
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if (playerOne.Schiffe.Any(c =>
                                 c.Positionen[0] > y && c.Positionen[0] - y <= c.FixedSize && c.Positionen[2] == 3 && c.Positionen[1] == x)) // Oben
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if (playerOne.Schiffe.Any(c =>
                                 c.Positionen[1] > x && c.Positionen[1] - x <= c.FixedSize && c.Positionen[2] == 1 && c.Positionen[0] == y))
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if (playerOne.Schiffe.Any(c =>
                                 c.Positionen[1] < x && x - c.Positionen[1] <= c.FixedSize && c.Positionen[2] == 2 && c.Positionen[0] == y))
                        Console.BackgroundColor = ConsoleColor.Red;
                    else
                        Console.BackgroundColor = ConsoleColor.Green;

                    Console.Write("  ");
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public static void AskForShipPositions()
        {
            int[] positions;
            /*Console.WriteLine("Wo soll das Schlachtschiff liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("Schlachtschiff", 5, positions));

            Console.WriteLine("Wo soll das Kreuzer liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("Kreuzer", 4, positions));

            Console.WriteLine("Wo soll das Kreuzer liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("Kreuzer", 4, positions));

            Console.WriteLine("Wo soll das Zerstörer liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("Zerstörer", 3, positions));

            Console.WriteLine("Wo soll das Zerstörer liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("Zerstörer", 3, positions));

            Console.WriteLine("Wo soll das Zerstörer liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("Zerstörer", 3, positions));

            Console.WriteLine("Wo soll das U-Boot liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("U-Boot", 2, positions));

            Console.WriteLine("Wo soll das U-Boot liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("U-Boot", 2, positions));

            Console.WriteLine("Wo soll das U-Boot liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("U-Boot", 2, positions));*/

            Console.WriteLine("Wo soll das U-Boot liegen?");
            positions = AskForPositions();
            playerOne.Schiffe.Add(new Schiff("U-Boot", 2, positions));
        }

        public static int[] AskForPositions(bool fix = true, int minValue = 0, int maxValue = 9)
        {
            int y, x, direction;
            Console.WriteLine("Bitte geben Sie die Y-Kordinate ein.");
            y = Convert.ToInt32(Console.ReadLine()) - (fix ? 1 : 0);
            Console.WriteLine("Bitte geben Sie die X-Kordinate ein.");
            x = Convert.ToInt32(Console.ReadLine()) - (fix ? 1 : 0);
            Console.WriteLine(
                "In welche Richtung soll das Schiff gucken? (1 => Rechts, 2 => Links, 3 => Oben, 4 => Unten)");
            direction = Convert.ToInt32(Console.ReadLine());

            if (x > maxValue) x = maxValue;
            if (x < minValue) x = minValue;
            if (y > maxValue) y = maxValue;
            if (y < minValue) y = minValue;
            if (direction < 1) direction = 1;
            if (direction > 4) direction = 4;
            return new[] { y, x, direction };
        }

        public class Player
        {
            private string _name;
            public List<Schiff> Schiffe = new List<Schiff>();

            public Player(String name)
            {
                this._name = name;
            }

            public String Name
            {
                get => _name;
            }
        }

        public class Schiff
        {
            private string _name;
            private int _size;
            public int[] Positionen;

            public Schiff(String name, int size, int[] positionen)
            {
                this._name = name;
                this._size = size;
                Positionen = positionen;
            }

            public String Name
            {
                get => _name;
            }

            public int Size
            {
                get => _size;
            }

            public int FixedSize
            {
                get => _size - 1;
            }
        }
    }
}