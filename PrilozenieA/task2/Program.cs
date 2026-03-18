using System;
class Program
{
    static void Main()
    {
        int n, first, last, sum;
        Console.Write("Введите трехзначное число: ");
        n = Convert.ToInt32(Console.ReadLine());
        first = n / 100;
        last = n % 10;
        sum = first + last;
        Console.WriteLine("Сумма первой и последней цифры = " + sum);
    }
}