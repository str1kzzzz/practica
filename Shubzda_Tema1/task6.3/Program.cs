using System;
class Program
{
    static void Main()
    {
        int n = 100;

        while (n <= 999)
        {
            int a = n / 100;
            int b = (n / 10) % 10;
            int c = n % 10;
            if (a == b || a == c || b == c)
                Console.WriteLine(n);
            n++;
        }
    }
}