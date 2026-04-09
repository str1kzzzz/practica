using System;
delegate void DataAnalyzer(int[] data);
class Program
{
    static void AnalyzeData(int[] data, DataAnalyzer method)
    {
        method(data);
    }
    static void CalculateAverage(int[] data)
    {
        double sum = 0;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i];
        }
        Console.WriteLine("Среднее = " + sum / data.Length);
    }
    static void FindMaximum(int[] data)
    {
        int max = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] > max)
                max = data[i];
        }
        Console.WriteLine("Максимум = " + max);
    }
    static void Main()
    {
        int[] a = { 2, 5, 8, 3, 1 };
        AnalyzeData(a, CalculateAverage);
        AnalyzeData(a, FindMaximum);
    }
}