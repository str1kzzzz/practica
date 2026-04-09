using System;
class AccessDeniedException : Exception
{
    public AccessDeniedException() { }
    public AccessDeniedException(string message) : base(message) { }
    public AccessDeniedException(string message, Exception inner)
        : base(message, inner) { }
}
class AccessControl
{
    public void CheckAccessTime(int hour)
    {
        if (hour < 9 || hour > 18)
        {
            throw new AccessDeniedException("Доступ запрещён: вне рабочего времени");
        }
        Console.WriteLine("Доступ разрешён");
    }
}
class Program
{
    static void Main()
    {
        AccessControl a = new AccessControl();
        try
        {
            Console.Write("Введите час: ");
            int h = Convert.ToInt32(Console.ReadLine());
            a.CheckAccessTime(h);
        }
        catch (AccessDeniedException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Другая ошибка: " + e.Message);
        }
    }
}