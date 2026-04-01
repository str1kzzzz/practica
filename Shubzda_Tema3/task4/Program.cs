using System;
public partial class user
{
    public string name;
    public int followers;
    public int posts;
    public DateTime last;
}
public partial class user
{
    public bool popular(int min)
    {
        return followers > min;
    }
    public bool inactive(int days)
    {
        return (DateTime.Now - last).Days > days;
    }
}
class net
{
    public user[] a;
    public net(user[] x)
    {
        a = x;
    }
    public user[] getpopular(int min)
    {
        int c = 0;
        for (int i = 0; i < a.Length; i++)
            if (a[i].popular(min))
                c++;
        user[] r = new user[c];
        int k = 0;
        for (int i = 0; i < a.Length; i++)
            if (a[i].popular(min))
                r[k++] = a[i];
        return r;
    }
    public user[] getinactive(int d)
    {
        int c = 0;
        for (int i = 0; i < a.Length; i++)
            if (a[i].inactive(d))
                c++;
        user[] r = new user[c];
        int k = 0;
        for (int i = 0; i < a.Length; i++)
            if (a[i].inactive(d))
                r[k++] = a[i];
        return r;
    }
}
class program
{
    static void Main()
    {
        user[] a ={
            new user{name="ivan",followers=100,posts=10,last=DateTime.Now.AddDays(-5)},
            new user{name="anna",followers=500,posts=20,last=DateTime.Now.AddDays(-30)},
            new user{name="oleg",followers=50,posts=5,last=DateTime.Now.AddDays(-1)}
        };
        net n = new net(a);
        var p = n.getpopular(100);
        for (int i = 0; i < p.Length; i++)
            Console.WriteLine(p[i].name);
        var iusers = n.getinactive(10);
        for (int i = 0; i < iusers.Length; i++)
            Console.WriteLine(iusers[i].name);
        Console.ReadLine();
    }
}