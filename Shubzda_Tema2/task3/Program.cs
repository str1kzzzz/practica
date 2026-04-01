using System;
class program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int[,] m = new int[n, n];
        Random r = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                m[i, j] = r.Next(a, b + 1);
                Console.Write(m[i, j] + " ");
            }
            Console.WriteLine();
        }
        int s = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (m[i, j] > 0)
                    s += m[i, j] * m[i, j];

        Console.WriteLine(s);
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = 0; j < n; j++)
                sum += m[i, j];
            Console.WriteLine(sum);
        }
        Console.ReadLine();
    }
}