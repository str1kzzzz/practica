using System;
using System.Collections.Generic;
interface ICurrencyObserver
{
    void Update(double rate);
}
class ForexMarket
{
    List<ICurrencyObserver> observers = new List<ICurrencyObserver>();
    double rate;
    public void Add(ICurrencyObserver o)
    {
        observers.Add(o);
    }
    public void Remove(ICurrencyObserver o)
    {
        observers.Remove(o);
    }
    public void SetRate(double r)
    {
        rate = r;
        Notify();
    }
    void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].Update(rate);
        }
    }
}
class Trader : ICurrencyObserver
{
    public void Update(double rate)
    {
        Console.WriteLine("Трейдер получил курс: " + rate);
    }
}
class Bank : ICurrencyObserver
{
    public void Update(double rate)
    {
        Console.WriteLine("Банк получил курс: " + rate);
    }
}
class Program
{
    static void Main()
    {
        ForexMarket m = new ForexMarket();
        Trader t = new Trader();
        Bank b = new Bank();
        m.Add(t);
        m.Add(b);
        m.SetRate(90.5);
        m.SetRate(91.2);
    }
}