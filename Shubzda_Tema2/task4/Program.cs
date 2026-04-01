using System;
class program
{
    static void Main()
    {
        int[] a = { 10, 20, 30, 40, 25 };
        double sum = 0;
        for (int i = 0; i < a.Length; i++)
            sum += a[i];
        double avg = sum / a.Length;
        int index = 0;
        double min = Math.Abs(a[0] - avg);
        for (int i = 1; i < a.Length; i++)
        {
            double d = Math.Abs(a[i] - avg);
            if (d < min)
            {
                min = d;
                index = i;
            }
        }
        Console.WriteLine("Ближайший элемент: " + a[index] + " индекс " + index);
        int s = (int)sum;
        if (s >= 1000 && s <= 9999)
            Console.WriteLine("Сумма четырехзначная");
        else
            Console.WriteLine("Сумма не четырехзначная");
        Console.ReadLine();
    }
}