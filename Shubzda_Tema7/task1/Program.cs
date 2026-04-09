using System;
class OverweightLuggageException : Exception
{
    public OverweightLuggageException() { }
    public OverweightLuggageException(string message) : base(message) { }
    public OverweightLuggageException(string message, Exception inner)
        : base(message, inner) { }
}
class Luggage
{
    public void CheckWeight(int weight)
    {
        if (weight > 23)
        {
            throw new OverweightLuggageException("Вес превышает 23 кг");
        }
        Console.WriteLine("Вес допустим");
    }
}
class Program
{
    static void Main()
    {
        Luggage l = new Luggage();
        try
        {
            Console.Write("Введите вес багажа: ");
            int w = Convert.ToInt32(Console.ReadLine());
            l.CheckWeight(w);
        }
        catch (OverweightLuggageException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Другая ошибка: " + e.Message);
        }
    }
}