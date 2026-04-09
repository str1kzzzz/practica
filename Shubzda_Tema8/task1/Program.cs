using System;
using System.Collections;
using Internal;
using System.Collections.Generic;
class Customer
{
    public int Id;
    public string Name;
    public string ServiceType;
    public Customer(int id, string name, string service)
    {
        Id = id;
        Name = name;
        ServiceType = service;
    }
}
class BankQueue
{
    Queue q = new Queue();
    public void AddCustomer(Customer c)
    {
        q.Enqueue(c);
    }
    public void ServeCustomer()
    {
        if (q.Count > 0)
        {
            Customer c = (Customer)q.Dequeue();
            Console.WriteLine("Обслужен: " + c.Name);
        }
        else
        {
            Console.WriteLine("Очередь пуста");
        }
    }
    public void ShowAll()
    {
        foreach (Customer c in q)
        {
            Console.WriteLine(c.Id + " " + c.Name + " " + c.ServiceType);
        }
    }
    public void FindByService(string service)
    {
        foreach (Customer c in q)
        {
            if (c.ServiceType == service)
            {
                Console.WriteLine("Найден: " + c.Name);
            }
        }
    }
}
class Program
{
    static void Main()
    {
        BankQueue b = new BankQueue();
        b.AddCustomer(new Customer(1, "Иван", "Кредит"));
        b.AddCustomer(new Customer(2, "Анна", "Вклад"));
        b.AddCustomer(new Customer(3, "Олег", "Кредит"));
        Console.WriteLine("Очередь:");
        b.ShowAll();
        Console.WriteLine("Поиск (Кредит):");
        b.FindByService("Кредит");
        b.ServeCustomer();
        b.ServeCustomer();
        Console.WriteLine("После обслуживания:");
        b.ShowAll();
    }
}