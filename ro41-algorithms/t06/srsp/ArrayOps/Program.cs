class Program
{
    static void RunTest(int[] original, int x)
    {
        int[] a = (int[])original.Clone();

        Console.WriteLine($"Исходный массив: [{string.Join(", ", a)}]");
        Console.WriteLine($"Сумма элементов: {ArrayOps.Sum(a)}");
        Console.WriteLine($"Индекс первого минимального элемента): {ArrayOps.IndexOfMin(a)}");
        Console.WriteLine($"Количество элементов больше {x} : {ArrayOps.CountGreater(a, x)}");

        ArrayOps.Reverse(a);
        Console.WriteLine($"Массив после Reverse: [{string.Join(", ", a)}]");
        Console.WriteLine(new string('-', 40));
    }

    static void Main()
    {
        int[][] tests = new int[][]
        {
            new int[] { 4, 1, 7, 3, 9 },
            new int[] { 5 },
            new int[] { -2, -7, -4 },
            new int[] { 2, 2, 2 }
        };

        int x = 2; 
        foreach (var test in tests)
        {
            RunTest(test, x);
        }
    }
}

static class ArrayOps
{
    public static int Sum(int[] a)
    {
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
        {
            sum += a[i];
        }
        return sum;
    }

    public static int IndexOfMin(int[] a)
    {
        if (a.Length == 0) return -1;
        
        int minIndex = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < a[minIndex])
            {
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static int CountGreater(int[] a, int x)
    {
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > x)
            {
                count++;
            }
        }
        return count;
    }

    public static void Reverse(int[] a)
    {
        int n = a.Length;
        for (int i = 0; i < n / 2; i++)
        {
            int temp = a[i];
            a[i] = a[n - 1 - i];
            a[n - 1 - i] = temp;
        }
    }
}