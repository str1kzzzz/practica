abstract class album
{
    public string t, a;
    public int y;
    public album(string t1, string a1, int y1)
    {
        t = t1;
        a = a1;
        y = y1;
    }
}
sealed class rock : album
{
    public rock(string t, string a, int y) : base(t, a, y) { }
}
sealed class pop : album
{
    public pop(string t, string a, int y) : base(t, a, y) { }
}
class lib
{
    public album[] a;
    public lib(album[] x)
    {
        a = x;
    }
    public album max()
    {
        album m = a[0];
        for (int i = 1; i < a.Length; i++)
            if (a[i].y > m.y)
                m = a[i];
        return m;
    }
    public album[] find(string name)
    {
        int c = 0;
        for (int i = 0; i < a.Length; i++)
            if (a[i].a == name)
                c++;
        album[] r = new album[c];
        int k = 0;
        for (int i = 0; i < a.Length; i++)
            if (a[i].a == name)
                r[k++] = a[i];
        return r;
    }
}
class program
{
    static void Main()
    {
        album[] a ={
            new rock("a1","m",2000),
            new pop("a2","r",2015),
            new rock("a3","m",2020)
        };
        lib l = new lib(a);
        var x = l.max();
        System.Console.WriteLine(x.t + " " + x.y);
        var f = l.find("m");
        for (int i = 0; i < f.Length; i++)
            System.Console.WriteLine(f[i].t);
        System.Console.ReadLine();
    }
}