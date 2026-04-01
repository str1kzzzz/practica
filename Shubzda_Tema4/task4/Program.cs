using System;
static class ext
{
    public static string stars(this string s)
    {
        string r = "";
        for (int i = 0; i < s.Length; i++)
        {
            char c = char.ToLower(s[i]);
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y')
                r += '*';
            else
                r += s[i];
        }
        return r;
    }
}
class program
{
    static void Main()
    {
        string s = "hello world";
        Console.WriteLine(s.stars());
        Console.ReadLine();
    }
}