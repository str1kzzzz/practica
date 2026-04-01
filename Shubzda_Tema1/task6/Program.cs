using System;
class Program
{
    static void Main()
    {
        int n;
        Console.Write("Введите номер вагона: ");
        n = Convert.ToInt32(Console.ReadLine());
        if (n >= 1 && n <= 17)
        {
            if (n >= 10)
                Console.WriteLine("Купейный вагон");
            else
                Console.WriteLine("Плацкартный вагон");
        }
        else
        {
            Console.WriteLine("Такого вагона нет");
        }
    }
}