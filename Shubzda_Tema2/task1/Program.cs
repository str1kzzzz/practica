class program
{
    static void Main()
    {
        int[] a = { 10, 7, 15, 3, 20, 8 };
        int sum = 0;
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 5 == 0)
            {
                sum += a[i];
                count++;
            }
        }
        if (count > 0)
            System.Console.WriteLine("Среднее = " + (double)sum / count);
        else
            System.Console.WriteLine("Нет чисел кратных 5");
        System.Console.ReadLine();
    }
}