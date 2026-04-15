using System;
interface ITicket
{
    void Book();
}
class PlaneTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Билет на самолет");
    }
}
class TrainTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Билет на поезд");
    }
}
class BusTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Билет на автобус");
    }
}
abstract class TicketFactory
{
    public abstract ITicket CreateTicket();
}
class PlaneFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new PlaneTicket();
    }
}
class TrainFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new TrainTicket();
    }
}
class BusFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new BusTicket();
    }
}
class Program
{
    static void Main()
    {
        TicketFactory f;
        f = new PlaneFactory();
        ITicket t1 = f.CreateTicket();
        t1.Book();
        f = new TrainFactory();
        ITicket t2 = f.CreateTicket();
        t2.Book();
        f = new BusFactory();
        ITicket t3 = f.CreateTicket();
        t3.Book();
    }
}