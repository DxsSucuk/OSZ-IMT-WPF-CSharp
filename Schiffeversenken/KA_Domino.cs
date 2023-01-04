using System;
using System.Collections.Generic;

public class KA_Domino
{
    public static void Main(string[] args)
    {
        List<int[]> written = new List<int[]>();

        for (int i = 0; i <= 6; i++)
        {
            String end = "";
            for (int j = 0; j <= 6; j++)
            {
                if (j < i) continue;
                
                int[] asArray = { j, i };
                if (!written.Contains(asArray))
                {
                    end += $"({i}|{j})";
                    written.Add(asArray);
                }
            }
            Console.WriteLine(end);
        }
    }
}