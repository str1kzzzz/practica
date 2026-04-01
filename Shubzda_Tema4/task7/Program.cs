using System;
class program
{
    static string getstudentgrade(int m)
    {
        if (m >= 90) return "A";
        if (m >= 75) return "B";
        if (m >= 50) return "C";
        return "D";
    }
    static string getstudentgrade(double m)
    {
        if (m >= 90) return "A";
        if (m >= 75) return "B";
        if (m >= 50) return "C";
        return "D";
    }
    static void Main()
    {
        Console.WriteLine(getstudentgrade(85));
        Console.WriteLine(getstudentgrade(89.5));
        Console.ReadLine();
    }
}