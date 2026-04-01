using System;
class Program
{
    static void Main()
    {
        double A, result;
        int N;
        Console.Write("Введите A: ");
        A = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите N: ");
        N = Convert.ToInt32(Console.ReadLine());
        result = A;
        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine(result.ToString("F4"));
            result = result * A;
        }
    }
}