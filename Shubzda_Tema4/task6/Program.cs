using System;
class program
{
    static void daysbetweendates(ref int d1, ref int m1, ref int y1,
                                ref int d2, ref int m2, ref int y2,
                                out int days)
    {
        DateTime a = new DateTime(y1, m1, d1);
        DateTime b = new DateTime(y2, m2, d2);
        days = Math.Abs((b - a).Days);
    }
    static void Main()
    {
        int d1 = 1, m1 = 1, y1 = 2020;
        int d2 = 10, m2 = 1, y2 = 2020;
        int d3 = 5, m3 = 3, y3 = 2021;
        int d4 = 20, m4 = 3, y4 = 2021;
        int d5 = 1, m5 = 1, y5 = 2022;
        int d6 = 1, m6 = 2, y6 = 2022;
        int r;
        daysbetweendates(ref d1, ref m1, ref y1, ref d2, ref m2, ref y2, out r);
        Console.WriteLine(r);
        daysbetweendates(ref d3, ref m3, ref y3, ref d4, ref m4, ref y4, out r);
        Console.WriteLine(r);
        daysbetweendates(ref d5, ref m5, ref y5, ref d6, ref m6, ref y6, out r);
        Console.WriteLine(r);
        Console.ReadLine();
    }
}