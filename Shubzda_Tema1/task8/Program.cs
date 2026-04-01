using System;
using Internal;
class Program
{
    static void Main()
    {
        int N;
        double S = 0;
        Console.Write("Введите N: ");
        N = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= N; i++)
        {
            S = S + 1.0 / i;
        }
        Console.WriteLine("Сумма = " + S.ToString("F4"));
    }
}