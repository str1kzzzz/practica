using System;
using System.Text;
class program
{
    static void Main()
    {
        StringBuilder s = new StringBuilder("hello world");
        for (int i = 0; i < s.Length; i++)
            s[i] = char.ToUpper(s[i]);
        Console.WriteLine(s);
        Console.ReadLine();
    }
}