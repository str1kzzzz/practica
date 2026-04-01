using System;
class Program
{
    static void Main()
    {
        for (int n = 100; n <= 999; n++)
        {
            int a = n / 100;
            int b = (n / 10) % 10;
            int c = n % 10;
            if (a == b || a == c || b == c)
                Console.WriteLine(n);
        }
    }
}