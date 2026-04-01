using System;
class Program
{
    static void Main()
    {
        double x, y;
        Console.Write("Введите x: ");
        x = Convert.ToDouble(Console.ReadLine());
        if (x > 2)
        {
            y = Math.Pow(x, 3) * Math.Sqrt(x - 2);
        }
        else if (x == 2)
        {
            y = x * Math.Sin(2 * x);
        }
        else
        {
            y = Math.Exp(-2 * x) * Math.Cos(2 * x);
        }
        Console.WriteLine("y = " + y.ToString("F6"));
    }
}