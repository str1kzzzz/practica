using System;
class program
{
    static void permute(string s, string prefix)
    {
        if (s.Length == 0)
        {
            Console.WriteLine(prefix);
            return;
        }
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            string rest = s.Substring(0, i) + s.Substring(i + 1);
            permute(rest, prefix + c);
        }
    }
    static void Main()
    {
        string s = "abc";
        permute(s, "");
        Console.ReadLine();
    }
}