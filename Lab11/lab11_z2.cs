using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть дату (у форматі yyyy-MM-dd): ");
        DateTime targetDate = DateTime.Parse(Console.ReadLine());

        DateTime currentDate = DateTime.Now;

        if (targetDate > currentDate)
        {
            TimeSpan remainingDays = targetDate - currentDate;
            Console.WriteLine("Днів до вказаної дати: " + remainingDays.Days);
        }
        else
        {
            Console.WriteLine("Вказана дата вже минула.");
        }
    }
}
