Console.Write("Введите целое число: ");
int number = int.Parse(Console.ReadLine() ?? "0");

    if (number < 0)
    {
        number = -number;
    }

    int count = 0;
    int sum = 0;

do
{
    int digit = number % 10;
    sum += digit;
    count++;
    number /= 10;
} 
while (number > 0);

Console.WriteLine($"Количество цифр: {count}");
Console.WriteLine($"Сумма цифр: {sum}");