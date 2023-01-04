using System;

public class Geisterspiel
{
    private static readonly int ghostDoor = new Random().Next(1, 6);
    private static int fuckups = 0;
    public static void main(string[] args)
    {
        choiceDoor();
    }

    public static void choiceDoor()
    {
        Console.WriteLine("Hinter einer der Türen versteckt sich der Geist.");
        Console.WriteLine("Welche Tür möchtest du öffnen (1 bis 5)?");
        string input = Console.ReadLine();
        int value = 1;
        try
        {
            value = Convert.ToInt32(input);
        }
        catch (Exception ignore)
        {
            Console.WriteLine("Fehlerhafte Nummer nutze 1!");
        }

        if (value < 1 || value > 5)
        {
            Console.WriteLine("Fehlerhafte Nummer nutze 1!");
            value = 1;
        }

        if (value == ghostDoor)
        {
            Console.WriteLine("Hier ist ein Geist!");
            Console.WriteLine("Deine Punkte: " + fuckups);
        }
        else
        {
            Console.WriteLine("Kein Geist!");
            fuckups++;
            choiceDoor();
        }
    }
}