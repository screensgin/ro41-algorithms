using System;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CurrentCulture;

Console.WriteLine("Расчет стоимости поездки");

Console.Write("Введите расстояние (км): ");
if (!double.TryParse(Console.ReadLine(), out double distance) || distance <= 0)
{
    Console.WriteLine("Ошибка некорректный ввод расстояния. Введите положительное число.");
    return;
}

Console.Write("Введите расход топлива (л на 100 км): ");
if (!double.TryParse(Console.ReadLine(), out double consumptionRate) || consumptionRate <= 0)
{
    Console.WriteLine("Ошибка некорректный ввод расхода. Введите положительное число.");
    return;
}

Console.Write("Введите цену одного литра: ");
if (!decimal.TryParse(Console.ReadLine(), out decimal pricePerLiter) || pricePerLiter <= 0)
{
    Console.WriteLine("Ошибка некорректный ввод цены. Введите положительное число .");
    return;
}

double totalLiters = (distance / 100) * consumptionRate;

decimal totalCost = (decimal)totalLiters * pricePerLiter;


Console.WriteLine("Результат расчета");
Console.WriteLine($"Расход топлива: {totalLiters:F1} л");
Console.WriteLine($"Стоимость поездки: {totalCost:N2} тг");