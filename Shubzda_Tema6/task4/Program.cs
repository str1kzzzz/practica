using System;
class FileDownloader
{
    public event EventHandler DownloadProgressChanged;
    public void StartDownload()
    {
        for (int i = 0; i <= 100; i += 50)
        {
            Console.WriteLine("Загрузка: " + i + "%");
            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(this, EventArgs.Empty);
            }
        }
    }
}
class ProgressBar
{
    public void Update(object sender, EventArgs e)
    {
        Console.WriteLine("Обновление индикатора");
    }
}
class Logger
{
    public void Log(object sender, EventArgs e)
    {
        Console.WriteLine("Логирование загрузки");
    }
}
class DownloadMonitor
{
    public DownloadMonitor(FileDownloader d, ProgressBar p, Logger l)
    {
        d.DownloadProgressChanged += p.Update;
        d.DownloadProgressChanged += l.Log;
    }
}
class Program
{
    static void Main()
    {
        FileDownloader d = new FileDownloader();
        ProgressBar p = new ProgressBar();
        Logger l = new Logger();
        DownloadMonitor m = new DownloadMonitor(d, p, l);
        d.StartDownload();
    }
}