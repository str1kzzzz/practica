using System;
using System.Collections.Generic;
class employee
{
    public string name;
    public string dep;
    public employee(string n, string d)
    {
        name = n;
        dep = d;
    }
}
static class emphelper
{
    public static List<employee> findemployeesbydepartment(List<employee> a, string dep)
    {
        List<employee> r = new List<employee>();
        for (int i = 0; i < a.Count; i++)
            if (a[i].dep == dep)
                r.Add(a[i]);
        return r;
    }
}
class program
{
    static void Main()
    {
        List<employee> a = new List<employee>()
        {
            new employee("Иван","IT"),
            new employee("Анна","HR"),
            new employee("Олег","IT")
        };
        var r = emphelper.findemployeesbydepartment(a, "IT");
        for (int i = 0; i < r.Count; i++)
            Console.WriteLine(r[i].name);
        Console.ReadLine();
    }
}