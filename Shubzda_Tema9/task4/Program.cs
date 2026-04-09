using System;
using System.IO;
class FileWatcher
{
    FileSystemWatcher watcher;
    string logFile = "log.csv";
    public FileWatcher(string path)
    {
        watcher = new FileSystemWatcher();
        watcher.Path = path;
        watcher.EnableRaisingEvents = true;
        watcher.IncludeSubdirectories = false;
        watcher.Created += OnCreated;
        watcher.Deleted += OnDeleted;
        watcher.Changed += OnChanged;
        watcher.Renamed += OnRenamed;
    }
    void WriteLog(string action, string fileName)
    {
        StreamWriter sw = new StreamWriter(logFile, true);
        sw.WriteLine(DateTime.Now + ";" + action + ";" + fileName);
        sw.Close();
    }
    void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("Создан: " + e.Name);
        WriteLog("Created", e.Name);
    }
    void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("Удален: " + e.Name);
        WriteLog("Deleted", e.Name);
    }
    void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("Изменен: " + e.Name);
        WriteLog("Changed", e.Name);
    }
    void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine("Переименован: " + e.OldName + " -> " + e.Name);
        WriteLog("Renamed", e.OldName + " -> " + e.Name);
    }
}
class Program
{
    static void Main()
    {
        string path = "WatchFolder";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        if (!File.Exists("log.csv"))
        {
            StreamWriter sw = new StreamWriter("log.csv");
            sw.WriteLine("Date;Action;FileName");
            sw.Close();
        }
        FileWatcher fw = new FileWatcher(path);
        Console.WriteLine("Отслеживание папки: " + Path.GetFullPath(path));
        Console.WriteLine("Нажмите Enter для выхода");
        Console.ReadLine();
    }
}