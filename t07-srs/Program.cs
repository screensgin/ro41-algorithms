using System;

Console.WriteLine("Калькулятор");


Console.Write("Введите первое число: ");
if (!double.TryParse(Console.ReadLine(), out double num1))
{
    Console.WriteLine("Ошибка введено некорректное число");
    return;
}


Console.Write("Введите операцию (+, -, *, /): ");
string? op = Console.ReadLine()?.Trim();

Console.Write("Введите второе число: ");
if (!double.TryParse(Console.ReadLine(), out double num2))
{
    Console.WriteLine("Ошибка введено некорректное число");
    return;
}

if (op == "/" && num2 == 0)
{
    Console.WriteLine("Ошибка деление на ноль невозможно");
    return;
}


string resultMessage = op switch
{
    "+" => $"Результат: {num1 + num2}",
    "-" => $"Результат: {num1 - num2}",
    "*" => $"Результат: {num1 * num2}",
    "/" => $"Результат: {num1 / num2}",
    _   => "Ошибка неизвестный знак операции"
};


Console.WriteLine(resultMessage);