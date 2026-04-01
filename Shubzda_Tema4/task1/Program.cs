class program
{
    static int[] unique(int[] a)
    {
        int[] temp = new int[a.Length];
        int k = 0;
        for (int i = 0; i < a.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < k; j++)
                if (a[i] == temp[j])
                    found = true;
            if (!found)
                temp[k++] = a[i];
        }
        int[] r = new int[k];
        for (int i = 0; i < k; i++)
            r[i] = temp[i];
        return r;
    }
    static void Main()
    {
        int[] a = { 1, 2, 2, 3, 1, 4 };
        int[] r = unique(a);
        for (int i = 0; i < r.Length; i++)
            System.Console.Write(r[i] + " ");
        System.Console.ReadLine();
    }
}