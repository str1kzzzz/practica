using System;
using System.IO;
class FileManager
{
    public void CreateFile(string path, string text)
    {
        File.WriteAllText(path, text);
    }
    public void DeleteFile(string path)
    {
        if (File.Exists(path))
            File.Delete(path);
        else
            Console.WriteLine("Файл не существует: " + path);
    }
    public void CopyFile(string source, string dest)
    {
        File.Copy(source, dest, true);
    }
    public void MoveFile(string source, string dest)
    {
        if (File.Exists(dest))
            File.Delete(dest);
        File.Move(source, dest);
    }
    public void RenameFile(string source, string newName)
    {
        string folder = Path.GetDirectoryName(source);
        string dest = Path.Combine(folder, newName);
        if (File.Exists(dest))
            File.Delete(dest);
        File.Move(source, dest);
    }
}
class FileInfoProvider
{
    public void ShowInfo(string path)
    {
        if (File.Exists(path))
        {
            FileInfo f = new FileInfo(path);
            Console.WriteLine("Имя: " + f.Name);
            Console.WriteLine("Размер: " + f.Length + " байт");
            Console.WriteLine("Создан: " + f.CreationTime);
            Console.WriteLine("Изменен: " + f.LastWriteTime);
        }
        else
        {
            Console.WriteLine("Файл не найден: " + path);
        }
    }
    public void CompareSize(string file1, string file2)
    {
        if (File.Exists(file1) && File.Exists(file2))
        {
            FileInfo f1 = new FileInfo(file1);
            FileInfo f2 = new FileInfo(file2);
            if (f1.Length > f2.Length)
                Console.WriteLine(f1.Name + " больше");
            else if (f2.Length > f1.Length)
                Console.WriteLine(f2.Name + " больше");
            else
                Console.WriteLine("Файлы одинакового размера");
        }
        else
        {
            Console.WriteLine("Один из файлов не найден");
        }
    }
    public void ShowRights(string path)
    {
        if (File.Exists(path))
        {
            FileAttributes attr = File.GetAttributes(path);
            Console.WriteLine("Только чтение: " + attr.HasFlag(FileAttributes.ReadOnly));
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    Console.WriteLine("Чтение: доступно");
                }
            }
            catch
            {
                Console.WriteLine("Чтение: недоступно");
            }
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write))
                {
                    Console.WriteLine("Запись: доступна");
                }
            }
            catch
            {
                Console.WriteLine("Запись: недоступна");
            }
            Console.WriteLine("Выполнение: для обычного файла не применяется");
        }
        else
        {
            Console.WriteLine("Файл не найден");
        }
    }
}
class Program
{
    static void Main()
    {
        FileManager fm = new FileManager();
        FileInfoProvider info = new FileInfoProvider();
        string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "Files");
        string newDir = Path.Combine(baseDir, "NewFolder");
        Directory.CreateDirectory(baseDir);
        Directory.CreateDirectory(newDir);
        string file1 = Path.Combine(baseDir, "shubzda.yd");
        string copyFile = Path.Combine(baseDir, "copy_shubzda.yd");
        string movedFile = Path.Combine(newDir, "moved_shubzda.yd");
        string renamedFile = Path.Combine(newDir, "familiya.io");
        string file2 = Path.Combine(baseDir, "second.yd");
        fm.CreateFile(file1, "Это файл shubzda.yd");
        string text = File.ReadAllText(file1);
        Console.WriteLine(text);
        if (File.Exists(file1))
            Console.WriteLine("Файл существует");
        info.ShowInfo(file1);
        fm.CopyFile(file1, copyFile);
        if (File.Exists(copyFile))
            Console.WriteLine("Копия создана");
        fm.MoveFile(copyFile, movedFile);
        if (File.Exists(movedFile))
            Console.WriteLine("Файл перемещен");
        fm.RenameFile(movedFile, "familiya.io");
        if (File.Exists(renamedFile))
            Console.WriteLine("Файл переименован");
        try
        {
            fm.DeleteFile(Path.Combine(baseDir, "нет_файла.yd"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        fm.CreateFile(file2, "Текст");
        info.CompareSize(file1, file2);
        string[] filesYd = Directory.GetFiles(baseDir, "*.yd");
        for (int i = 0; i < filesYd.Length; i++)
        {
            File.Delete(filesYd[i]);
        }
        string[] allFiles = Directory.GetFiles(newDir);
        for (int i = 0; i < allFiles.Length; i++)
        {
            Console.WriteLine(allFiles[i]);
        }
        File.SetAttributes(renamedFile, FileAttributes.ReadOnly);
        try
        {
            File.WriteAllText(renamedFile, "Новая запись");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        info.ShowRights(renamedFile);
        File.SetAttributes(renamedFile, FileAttributes.Normal);
    }
}