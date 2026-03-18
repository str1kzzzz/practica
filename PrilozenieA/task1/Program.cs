using System;
class Program
{
    static void Main()
    {
        double distance, fuel, price, liters, cost;
        Console.Write("Расстояние до дачи (км) -> ");
        distance = Convert.ToDouble(Console.ReadLine());
        Console.Write("Расход бензина (литров на 100 км пробега) -> ");
        fuel = Convert.ToDouble(Console.ReadLine());
        Console.Write("Цена литра бензина (руб.) -> ");
        price = Convert.ToDouble(Console.ReadLine());
        liters = distance * 2 * fuel / 100;
        cost = liters * price;
        Console.WriteLine("Поездка на дачу и обратно обойдется в " + cost.ToString("F2") + " руб.");
    }
}