using System;
class Program
{
    static void Main()
    {
        double a, b, x;
        Console.Write("a = ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.Write("b = ");
        b = Convert.ToDouble(Console.ReadLine());
        x = a / 2 + b / 2;
        Console.WriteLine("{0:F2}/2+{1:F2}/2={2:F3}", a, b, x);
    }
}