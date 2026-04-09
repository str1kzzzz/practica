using System;
abstract class DeliveryMethod
{
    public abstract void Deliver();
}
class Courier : DeliveryMethod
{
    public override void Deliver()
    {
        Console.WriteLine("Доставка курьером");
    }
}
class Pickup : DeliveryMethod
{
    public override void Deliver()
    {
        Console.WriteLine("Самовывоз");
    }
}
class Post : DeliveryMethod
{
    public override void Deliver()
    {
        Console.WriteLine("Доставка почтой");
    }
}
class Program
{
    static void Main()
    {
        DeliveryMethod[] a = new DeliveryMethod[3];
        a[0] = new Courier();
        a[1] = new Pickup();
        a[2] = new Post();
        for (int i = 0; i < a.Length; i++)
        {
            a[i].Deliver();
        }
    }
}