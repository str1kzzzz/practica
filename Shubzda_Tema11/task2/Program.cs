using System;
interface ILogger
{
    string Log(string message);
}
class BasicLogger : ILogger
{
    public string Log(string message)
    {
        return message;
    }
}
class TimestampDecorator : ILogger
{
    ILogger logger;
    public TimestampDecorator(ILogger l)
    {
        logger = l;
    }
    public string Log(string message)
    {
        return DateTime.Now + " " + logger.Log(message);
    }
}
class SeverityDecorator : ILogger
{
    ILogger logger;
    string level;
    public SeverityDecorator(ILogger l, string lvl)
    {
        logger = l;
        level = lvl;
    }
    public string Log(string message)
    {
        return level + " " + logger.Log(message);
    }
}
class UserDecorator : ILogger
{
    ILogger logger;
    string user;
    public UserDecorator(ILogger l, string u)
    {
        logger = l;
        user = u;
    }
    public string Log(string message)
    {
        return user + " " + logger.Log(message);
    }
}
class Program
{
    static void Main()
    {
        ILogger logger = new BasicLogger();
        logger = new TimestampDecorator(logger);
        logger = new SeverityDecorator(logger, "INFO");
        logger = new UserDecorator(logger, "Admin");
        Console.WriteLine(logger.Log("Событие"));
    }
}