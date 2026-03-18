using System;
class Program
{
    static void Main()
    {
        double v, v1, t1, t2, s;
        Console.Write("Введите скорость лодки в стоячей воде v: ");
        v = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите скорость течения реки v1: ");
        v1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите время движения по озеру t1: ");
        t1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите время движения против течения t2: ");
        t2 = Convert.ToDouble(Console.ReadLine());
        s = v * t1 + (v - v1) * t2;
        Console.WriteLine("Путь лодки S = " + s.ToString("F2") + " км");
    }
}