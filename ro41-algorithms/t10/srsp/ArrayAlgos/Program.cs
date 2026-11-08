class Program
{
    static void Main()
    {
        System.Console.WriteLine("=== Тестирование BubbleSort и IsSorted ===");
        int[][] bubbleTests = new int[][]
        {
            new int[] { },
            new int[] { 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 5, 4, 3, 2, 1 },
            new int[] { 3, 1, 3, 2, 3 }
        };

        foreach (var test in bubbleTests)
        {
            int[] arr = (int[])test.Clone();
            string before = string.Join(", ", arr);
            bool sortedBefore = ArrayAlgos.IsSorted(arr);
            int comps = ArrayAlgos.BubbleSort(arr);
            string after = string.Join(", ", arr);
            bool sortedAfter = ArrayAlgos.IsSorted(arr);

            System.Console.WriteLine($"До: [{before}] (IsSorted: {sortedBefore})");
            System.Console.WriteLine($"После: [{after}] (IsSorted: {sortedAfter}) | Сравнений: {comps}\n");
        }

        int[] thousand = new int[1000];
        for (int i = 0; i < 1000; i++) thousand[i] = i;
        int comps1000 = ArrayAlgos.BubbleSort(thousand);
        System.Console.WriteLine($"Сравнений на отсортированном массиве из 1000 элементов: {comps1000} (ожидается 999)\n");

        System.Console.WriteLine("=== Тестирование CountOccurrences ===");
        int[] sortedA = { 1, 2, 2, 2, 5, 7 };
        int[] searchValues = { 2, 1, 7, 3, 9 };

        System.Console.WriteLine($"Массив: [{string.Join(", ", sortedA)}]");
        foreach (int x in searchValues)
        {
            int count = ArrayAlgos.CountOccurrences(sortedA, x);
            System.Console.WriteLine($"x = {x} -> вхождений: {count}");
        }
    }
}

static class ArrayAlgos
{
    public static bool IsSorted(int[] a)
    {
        if (a == null || a.Length <= 1) return true;
        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > a[i + 1]) return false;
        }
        return true;
    }

    public static int BubbleSort(int[] a)
    {
        if (a == null || a.Length <= 1) return 0;
        int comparisons = 0;
        int n = a.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                comparisons++;
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
        return comparisons;
    }

    private static int LowerBound(int[] a, int target)
    {
        int lo = 0, hi = a.Length;
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (a[mid] < target)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
        }
        return lo;
    }

    public static int CountOccurrences(int[] sortedA, int x)
    {
        int first = LowerBound(sortedA, x);
        int last = LowerBound(sortedA, x + 1);
        return last - first;
    }
}