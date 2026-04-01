using System;
class Program
{
    static void Main()
    {
        int n;
        Console.Write("Введите трехзначное число: ");
        n = Convert.ToInt32(Console.ReadLine());
        int a = n / 100;
        int b = (n / 10) % 10;
        int c = n % 10;
        if (b * b == a * c)
            Console.WriteLine("Цифры образуют геометрическую прогрессию");
        else
            Console.WriteLine("Цифры НЕ образуют геометрическую прогрессию");
    }
}