using System;
delegate void OrderHandler(string order);
class CookOrder
{
    public void Cook(string order)
    {
        Console.WriteLine("Готовим: " + order);
    }
}
class DeliverOrder
{
    public void Deliver(string order)
    {
        Console.WriteLine("Доставляем: " + order);
    }
}
class Program
{
    static void Main()
    {
        CookOrder c = new CookOrder();
        DeliverOrder d = new DeliverOrder();
        OrderHandler h;
        h = c.Cook;
        h("Пицца");
        h = d.Deliver;
        h("Пицца");
    }
}