class a
{
    int x;
    int y;
    public a(int a, int b)
    {
        x = a;
        y = b;
    }
    public double f1()
    {
        return 4.0 / (x + 2) * y;
    }
    public double f2()
    {
        double r = 1;
        for (int i = 0; i < 10; i++)
            r *= y;
        return r;
    }
}
class program
{
    static void Main()
    {
        a obj = new a(2, 3);
        System.Console.WriteLine(obj.f1());
        System.Console.WriteLine(obj.f2());
        System.Console.ReadLine();
    }
}