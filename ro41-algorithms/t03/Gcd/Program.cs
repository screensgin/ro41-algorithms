class Program
{
    static void Main()
    {
        Console.WriteLine("Введите число a (целое неотрицательное):");
        string inputA = Console.ReadLine();
        
        Console.WriteLine("Введите число b (целое неотрицательное):");
        string inputB = Console.ReadLine();

        if (!int.TryParse(inputA, out int a) || !int.TryParse(inputB, out int b) || a < 0 || b < 0 || (a == 0 && b == 0))
        {
            Console.WriteLine("Ошибка: некорректный ввод или оба числа равны нулю.");
            return;
        }

        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }

        Console.WriteLine($"НОД: {a}");
    }
}
