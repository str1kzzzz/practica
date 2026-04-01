using System;
class program
{
    static void Main()
    {
        string s = "hello world";
        int max = 0;
        char res = ' ';
        for (int i = 0; i < s.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[i] == s[j])
                    count++;
            }
            if (count > max)
            {
                max = count;
                res = s[i];
            }
        }
        Console.WriteLine("Символ: " + res);
        Console.WriteLine("Количество: " + max);
        Console.ReadLine();
    }
}