using System;
using System.Linq;

public class KA_Durschnitt
{
    public static void main(string[] args)
    {
        int[] kilometer = { 123, 134, 120, 122 };
        Console.WriteLine("Durchschnittlicher Verbrauch: " + calculate(kilometer));
    }

    public static double calculate(int[] kilometer)
    {
        return kilometer.Average();
    }
}