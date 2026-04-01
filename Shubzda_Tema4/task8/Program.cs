using System;
class program
{
    static void sum(in int a, in int b, out int r)
    {
        r = a + b;
    }
    static void sum(in double a, in double b, out double r)
    {
        r = a + b;
    }
    static void Main()
    {
        int x;
        double y;
        int a = 5, b = 10;
        double c = 2.5, d = 3.5;
        sum(in a, in b, out x);
        sum(in c, in d, out y);
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.ReadLine();
    }
}