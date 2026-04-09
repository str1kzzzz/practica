using System;
delegate void ProcessingHandler();
class DataProcessor
{
    public event ProcessingHandler ProcessingCompleted;
    public void Process()
    {
        Console.WriteLine("Обработка данных...");
        if (ProcessingCompleted != null)
        {
            ProcessingCompleted();
        }
    }
}
class ReportGenerator
{
    public void CreateReport()
    {
        Console.WriteLine("Создан отчет");
    }
}
class Notifier
{
    public void Notify()
    {
        Console.WriteLine("Пользователь уведомлен");
    }
}
class Program
{
    static void Main()
    {
        DataProcessor p = new DataProcessor();
        ReportGenerator r = new ReportGenerator();
        Notifier n = new Notifier();
        p.ProcessingCompleted += r.CreateReport;
        p.ProcessingCompleted += n.Notify;
        p.Process();
    }
}