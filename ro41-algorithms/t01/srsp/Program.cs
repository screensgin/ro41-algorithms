namespace SrspTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Программа перевода секунд в часы, минуты и секунды ===");
            Console.Write("Введите количество секунд ");
            
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int totalSeconds))
            {
                Console.WriteLine("Ошибка, введено некорректное значение. Требуется целое число.");
                return;
            }

        
            if (totalSeconds < 0)
            {
                Console.WriteLine("Ошибка, количество секунд не может быть отрицательным.");
                return;
            }

            int hours = totalSeconds / 3600;
            int remainingSeconds = totalSeconds % 3600;
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;

            Console.WriteLine($"Результат: {hours} ч. {minutes} мин. {seconds} сек. " +
                              $"(Формат времени: {hours:D2}:{minutes:D2}:{seconds:D2})");
        }
    }
}