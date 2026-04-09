using System;
using System.Collections.Generic;
interface IListManager<T>
{
    void Add(T item);
    void Remove(T item);
    T GetAt(int index);
    IEnumerable<T> GetAll();
}
class SimpleListManager<T> : IListManager<T>
{
    private List<T> items = new List<T>();
    public void Add(T item)
    {
        items.Add(item);
    }
    public void Remove(T item)
    {
        items.Remove(item);
    }
    public T GetAt(int index)
    {
        return items[index];
    }
    public IEnumerable<T> GetAll()
    {
        return items;
    }
}
class ListManager<T>
{
    private IListManager<T> list;
    public ListManager(IListManager<T> list)
    {
        this.list = list;
    }
    public void PrintAll()
    {
        foreach (T item in list.GetAll())
        {
            Console.WriteLine(item);
        }
    }
    public bool Contains(T item)
    {
        foreach (T x in list.GetAll())
        {
            if (x.Equals(item))
            {
                return true;
            }
        }
        return false;
    }
}
class Program
{
    static void Main()
    {
        SimpleListManager<string> s = new SimpleListManager<string>();
        s.Add("Яблоко");
        s.Add("Банан");
        s.Add("Груша");
        ListManager<string> m = new ListManager<string>(s);
        m.PrintAll();
        Console.WriteLine(m.Contains("Банан"));
        Console.WriteLine(m.Contains("Апельсин"));
    }
}