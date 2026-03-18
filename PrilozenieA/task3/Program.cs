using System;
class Program
{
    static void Main()
    {
        double a, z1, z2;
        Console.Write("Введите alpha: ");
        a = Convert.ToDouble(Console.ReadLine());
        z1 = 1 - 0.25 * Math.Pow(Math.Sin(2 * a), 2) + Math.Cos(2 * a);
        z2 = Math.Pow(Math.Cos(a), 2) + Math.Pow(Math.Cos(a), 4);
        Console.WriteLine("z1 = " + z1.ToString("F6"));
        Console.WriteLine("z2 = " + z2.ToString("F6"));
        Console.WriteLine("Разница = " + Math.Abs(z1 - z2).ToString("F6"));
    }
}