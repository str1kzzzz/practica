using System;
class Program
{
    static void Main()
    {
        double monitor, block, keyboard, mouse;
        double one, three, total;
        int n;
        Console.Write("Цена монитора: ");
        monitor = Convert.ToDouble(Console.ReadLine());
        Console.Write("Цена системного блока: ");
        block = Convert.ToDouble(Console.ReadLine());
        Console.Write("Цена клавиатуры: ");
        keyboard = Convert.ToDouble(Console.ReadLine());
        Console.Write("Цена мыши: ");
        mouse = Convert.ToDouble(Console.ReadLine());
        one = monitor + block + keyboard + mouse;
        three = one * 3;
        Console.Write("Введите количество компьютеров N: ");
        n = Convert.ToInt32(Console.ReadLine());
        total = one * n;
        Console.WriteLine("Стоимость одного компьютера = " + one);
        Console.WriteLine("Стоимость 3 компьютеров = " + three);
        Console.WriteLine("Стоимость " + n + " компьютеров = " + total);
    }
}