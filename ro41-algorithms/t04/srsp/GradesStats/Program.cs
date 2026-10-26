int count = 0;
int sum = 0;
int fives = 0;

int g = Grades.Read();
while (g != Grades.Stop)
{
    if (Grades.IsValid(g))
    {
        count++;
        sum += g;
        if (g == Grades.Max)
        {
            fives++;
        }
    }
    g = Grades.Read();
}

Grades.PrintStats(count, sum, fives);

static class Grades
{
    public const int Min = 2;
    public const int Max = 5;
    public const int Stop = 0;

    public static int Read()
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int g))
        {
            return g;
        }
        return -1; 
    }

    public static bool IsValid(int g)
    {
        return g >= Min && g <= Max;
    }

    public static void PrintStats(int count, int sum, int fives)
    {
        if (count == 0)
        {
            Console.WriteLine("Оценок нет");
        }
        else
        {
            Console.WriteLine($"Количество оценок: {count}");
            Console.WriteLine($"Сумма оценок: {sum}");
            Console.WriteLine($"Количество пятерок: {fives}");
            Console.WriteLine($"Средний балл: {(double)sum / count:F2}");
        }
    }
}