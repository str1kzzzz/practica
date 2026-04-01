using System;
class program
{
    static void Main()
    {
        string s1 = "listen";
        string s2 = "silent";
        char[] a = s1.ToCharArray();
        char[] b = s2.ToCharArray();
        Array.Sort(a);
        Array.Sort(b);
        string r1 = new string(a);
        string r2 = new string(b);
        if (r1 == r2)
            Console.WriteLine("Анаграммы");
        else
            Console.WriteLine("Не анаграммы");
        Console.ReadLine();
    }
}