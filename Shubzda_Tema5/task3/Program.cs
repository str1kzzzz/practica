using System;

class OfficeEquipment
{
    public string Name;
}

interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

class LaserPrinter : OfficeEquipment, IPrinter
{
    public void Print()
    {
        Console.WriteLine(Name + " печатает");
    }
}

class DocumentScanner : OfficeEquipment, IScanner
{
    public void Scan()
    {
        Console.WriteLine(Name + " сканирует");
    }
}
class Program
{
    static void Main()
    {
        OfficeEquipment[] a = new OfficeEquipment[4];
        LaserPrinter p1 = new LaserPrinter();
        p1.Name = "HP";
        LaserPrinter p2 = new LaserPrinter();
        p2.Name = "Canon";
        DocumentScanner s1 = new DocumentScanner();
        s1.Name = "Epson";
        DocumentScanner s2 = new DocumentScanner();
        s2.Name = "Brother";
        a[0] = p1;
        a[1] = s1;
        a[2] = p2;
        a[3] = s2;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] is IScanner)
            {
                Console.WriteLine(a[i].Name);
            }
        }
    }
}