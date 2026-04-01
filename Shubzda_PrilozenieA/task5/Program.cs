using System;
class Program
{
    static void Main()
    {
        int n;
        Console.Write("Введите четырехзначное число: ");
        n = Convert.ToInt32(Console.ReadLine());
        int first = n / 1000;
        int second = (n / 100) % 10;
        int third = (n / 10) % 10;
        int fourth = n % 10;
        int result = second * 1000 + first * 100 + third * 10 + fourth;
        Console.WriteLine("Новое число: " + result);
    }
}