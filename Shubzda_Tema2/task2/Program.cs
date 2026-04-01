class program
{
    static void Main()
    {
        int[] a = { 1, 2, 3, 4, 5, 6, 7 };
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 != 0)
                count++;
        }
        System.Console.WriteLine("Количество нечетных = " + count);
        System.Console.ReadLine();
    }
}