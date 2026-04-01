class program
{
    static void shiftleft3(ref double a, ref double b, ref double c)
    {
        double t = a;
        a = b;
        b = c;
        c = t;
    }
    static void Main()
    {
        double a1 = 1, b1 = 2, c1 = 3;
        double a2 = 4, b2 = 5, c2 = 6;
        shiftleft3(ref a1, ref b1, ref c1);
        shiftleft3(ref a2, ref b2, ref c2);
        System.Console.WriteLine(a1 + " " + b1 + " " + c1);
        System.Console.WriteLine(a2 + " " + b2 + " " + c2);
        System.Console.ReadLine();
    }
}