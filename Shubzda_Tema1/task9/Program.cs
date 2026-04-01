using System;
class Program
{
    static void Main()
    {
        double A = 0.1;
        double B = 2.1;
        int M = 20;
        double H = (B - A) / M;
        double x = A;
        double y;
        for (int i = 1; i <= M; i++)
        {
            y = x * x - Math.Exp(x);
            Console.WriteLine("x = " + x.ToString("F2") +
                              "   y = " + y.ToString("F4"));
            x = x + H;
        }
    }
}