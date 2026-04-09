using System;
using System.Collections.Generic;
class MyMultiMap<TKey, TValue>
{
    private Dictionary<TKey, List<TValue>> data = new Dictionary<TKey, List<TValue>>();
    public void Add(TKey key, TValue value)
    {
        if (!data.ContainsKey(key))
        {
            data[key] = new List<TValue>();
        }
        data[key].Add(value);
    }
    public void Remove(TKey key, TValue value)
    {
        if (data.ContainsKey(key))
        {
            data[key].Remove(value);
            if (data[key].Count == 0)
            {
                data.Remove(key);
            }
        }
    }
    public List<TValue> Find(TKey key)
    {
        if (data.ContainsKey(key))
        {
            return data[key];
        }
        return new List<TValue>();
    }
    public void ShowAll()
    {
        foreach (var item in data)
        {
            Console.Write(item.Key + ": ");
            for (int i = 0; i < item.Value.Count; i++)
            {
                Console.Write(item.Value[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
class MultiMapManager<TKey, TValue>
{
    private MyMultiMap<TKey, TValue> map = new MyMultiMap<TKey, TValue>();
    public void AddValue(TKey key, TValue value)
    {
        map.Add(key, value);
    }
    public void RemoveValue(TKey key, TValue value)
    {
        map.Remove(key, value);
    }
    public void FindValues(TKey key)
    {
        List<TValue> values = map.Find(key);
        if (values.Count == 0)
        {
            Console.WriteLine("Ничего не найдено");
        }
        else
        {
            Console.Write("Значения: ");
            for (int i = 0; i < values.Count; i++)
            {
                Console.Write(values[i] + " ");
            }
            Console.WriteLine();
        }
    }
    public void Show()
    {
        map.ShowAll();
    }
}
class Program
{
    static void Main()
    {
        MultiMapManager<string, string> m = new MultiMapManager<string, string>();
        m.AddValue("Фрукты", "Яблоко");
        m.AddValue("Фрукты", "Банан");
        m.AddValue("Фрукты", "Груша");
        m.AddValue("Овощи", "Морковь");
        m.AddValue("Овощи", "Картофель");
        m.Show();
        m.FindValues("Фрукты");
        m.RemoveValue("Фрукты", "Банан");
        m.Show();
    }
}