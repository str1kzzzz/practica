using System;
class Program
{
    static void Main()
    {
        int n;
        Console.Write("Введите трехзначное число: ");
        n = Convert.ToInt32(Console.ReadLine());
        int first = n / 100;
        int second = (n / 10) % 10;
        if (first > second)
            Console.WriteLine("Первая цифра больше");
        else if (second > first)
            Console.WriteLine("Вторая цифра больше");
        else
            Console.WriteLine("Цифры равны");
    }
}