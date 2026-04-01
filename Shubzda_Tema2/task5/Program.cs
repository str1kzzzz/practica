using System;
class program
{
    static void Main()
    {
        int[][] a = new int[][]
        {
            new int[]{3,6,9},
            new int[]{1,2},
            new int[]{5,5,5,5}
        };
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                double s1 = 0, s2 = 0;
                for (int k = 0; k < a[j].Length; k++)
                    s1 += a[j][k]
                for (int k = 0; k < a[j + 1].Length; k++)
                    s2 += a[j + 1][k];
                s1 /= a[j].Length;
                s2 /= a[j + 1].Length;
                if (s1 > s2)
                {
                    var t = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = t;
                }
            }
        }
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < a[i].Length; j++)
                Console.Write(a[i][j] + " ");
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}