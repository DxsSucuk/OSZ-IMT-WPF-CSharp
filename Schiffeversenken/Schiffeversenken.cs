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
                    if (checkForColission(y, x))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write("  ");
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public static void AskForShipPositions()
        {
            AskForPositions("Schlachtschiff", 5);

            AskForPositions("Kreuzer", 4);
            AskForPositions("Kreuzer", 4);

            AskForPositions("Zerstörer", 3);
            AskForPositions("Zerstörer", 3);
            AskForPositions("Zerstörer", 3);

            AskForPositions("U-Boot", 2);
            AskForPositions("U-Boot", 2);
            AskForPositions("U-Boot", 2);
            AskForPositions("U-Boot", 2);
        }

        public static void AskForPositions(String name, int size, int minValue = 0, int maxValue = 9, bool fix = true)
        {
            Console.WriteLine($"Wo soll das {name} liegen? ({size + "px"})");
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
            int[] positions = { y, x, direction };

            bool errorEntry = false;
            
            if (direction == 1 || direction == 2)
            {
                for (int colissionX = x; colissionX < (direction == 1 ? x + size : x - size); colissionX++)
                {
                    if (checkForColission(y, colissionX))
                    {
                        Console.WriteLine($"Auf dem Feld Y-{(y + 1) + ""} und X-{(colissionX + 1) + ""} befindet sich schon ein Schiff!");
                        errorEntry = true;
                        AskForPositions(name, size);
                        break;
                    }
                }
            } else
            {
                for (int colissionY = y; colissionY < (direction == 4 ? y + size : y - size); colissionY++)
                {
                    if (checkForColission(colissionY, x))
                    {
                        Console.WriteLine($"Auf dem Feld Y-{(colissionY + 1) + ""} und X-{(x + 1) + ""} befindet sich schon ein Schiff!");
                        errorEntry = true;
                        AskForPositions(name, size);
                        break;
                    }
                }
            }

            if (errorEntry) return;
            playerOne.Schiffe.Add(new Schiff(name, size, positions));
        }

        public static bool checkForColission(int y, int x)
        {
            if (playerOne.Schiffe.Any(c => c.Positionen[0] == y && c.Positionen[1] == x))
                return true;
            else if (playerOne.Schiffe.Any(c =>
                         c.Positionen[0] < y && y - c.Positionen[0] >= c.FixedSize && c.Positionen[2] == 4 &&
                         c.Positionen[1] == x)) // Unten
                return true;
            else if (playerOne.Schiffe.Any(c =>
                         c.Positionen[0] > y && c.Positionen[0] - y <= c.FixedSize && c.Positionen[2] == 3 &&
                         c.Positionen[1] == x)) // Oben
                return true;
            else if (playerOne.Schiffe.Any(c =>
                         c.Positionen[1] > x && c.Positionen[1] - x <= c.FixedSize && c.Positionen[2] == 1 &&
                         c.Positionen[0] == y))
                return true;
            else if (playerOne.Schiffe.Any(c =>
                         c.Positionen[1] < x && x - c.Positionen[1] <= c.FixedSize && c.Positionen[2] == 2 &&
                         c.Positionen[0] == y))
                return true;
            else
                return false;
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