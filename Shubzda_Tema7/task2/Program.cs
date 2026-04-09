using System;
class FileSecurity
{
    public void OpenSecureFile(string path)
    {
        throw new UnauthorizedAccessException("Нет доступа к файлу: " + path);
    }
}
class FileAccessManager
{
    FileSecurity fs = new FileSecurity();
    public void AccessFile(string path)
    {
        try
        {
            fs.OpenSecureFile(path);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Лог ошибки:");
            Console.WriteLine("Сообщение: " + e.Message);
            Console.WriteLine("Стек: " + e.StackTrace);
            throw new Exception("Ошибка доступа к защищенному файлу", e);
        }
    }
}
class Program
{
    static void Main()
    {
        FileAccessManager m = new FileAccessManager();
        try
        {
            m.AccessFile("secret.txt");
        }
        catch (Exception e)
        {
            Console.WriteLine("Обработано в Main:");
            Console.WriteLine(e.Message);
            if (e.InnerException != null)
            {
                Console.WriteLine("Внутреннее исключение:");
                Console.WriteLine(e.InnerException.Message);
            }
        }
    }
}