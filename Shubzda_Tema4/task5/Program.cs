using System;
abstract class device
{
    public abstract void turnon();
    public virtual void turnoff()
    {
        Console.WriteLine("Устройство выключено");
    }
}
class tv : device
{
    public override void turnon()
    {
        Console.WriteLine("TV is turning on");
    }
    public override void turnoff()
    {
        Console.WriteLine("TV is turning off");
    }
}
class radio : device
{
    public override void turnon()
    {
        Console.WriteLine("Radio is turning on");
    }
    public override void turnoff()
    {
        Console.WriteLine("Radio is turning off");
    }
}
class program
{
    static void Main()
    {
        device a = new tv();
        device b = new radio();
        a.turnon();
        a.turnoff();
        b.turnon();
        b.turnoff();
        Console.ReadLine();
    }
}