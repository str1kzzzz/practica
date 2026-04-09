using System;
using System.IO;
using System.Collections.Generic;
class CategoryItem
{
    public string Category;
    public string Name;
    public CategoryItem(string category, string name)
    {
        Category = category;
        Name = name;
    }
}
class CategoryFileReader
{
    public List<CategoryItem> ReadItems()
    {
        List<CategoryItem> items = new List<CategoryItem>();
        string[] lines = File.ReadAllLines("file.data");
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(' ');
            if (parts.Length >= 2)
            {
                items.Add(new CategoryItem(parts[0], parts[1]));
            }
        }
        return items;
    }
}
class CategoryProcessor
{
    public void CountByCategory(List<CategoryItem> items)
    {
        Dictionary<string, int> counts = new Dictionary<string, int>();
        for (int i = 0; i < items.Count; i++)
        {
            if (counts.ContainsKey(items[i].Category))
                counts[items[i].Category]++;
            else
                counts[items[i].Category] = 1;
        }
        foreach (var x in counts)
        {
            Console.WriteLine(x.Key + " " + x.Value);
        }
    }
}
class Program
{
    static void Main()
    {
        StreamWriter sw = new StreamWriter("file.data");
        sw.WriteLine("Фрукты Яблоко");
        sw.WriteLine("Фрукты Груша");
        sw.WriteLine("Овощи Морковь");
        sw.WriteLine("Фрукты Банан");
        sw.WriteLine("Овощи Картофель");
        sw.Close();
        CategoryFileReader reader = new CategoryFileReader();
        List<CategoryItem> items = reader.ReadItems();
        CategoryProcessor processor = new CategoryProcessor();
        processor.CountByCategory(items);
    }
}