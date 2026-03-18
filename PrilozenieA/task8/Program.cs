using System;
class Program
{
    static void Main()
    {
        double x = 5.2;
        double y;
        y = Math.Pow(Math.Sin(Math.Pow(x * x + 5, 2)), 3)
            - Math.Sqrt(x / 4);
        Console.WriteLine("x = " + x);
        Console.WriteLine("y = " + y.ToString("F6"));
    }
}