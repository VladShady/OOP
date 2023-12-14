using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть рядок з трьома різними датами (у форматі dd.MM.yyyy,dd.MM.yyyy,dd.MM.yyyy): ");
        string inputDates = Console.ReadLine();

        string[] dateStrings = inputDates.Split(',');

        DateTime[] dates = new DateTime[dateStrings.Length];

        for (int i = 0; i < dateStrings.Length; i++)
        {
            dates[i] = DateTime.ParseExact(dateStrings[i], "dd.MM.yyyy", null);
        }

        // a) рік з найменшим номером
        int minYear = dates[0].Year;
        foreach (var date in dates)
        {
            if (date.Year < minYear)
            {
                minYear = date.Year;
            }
        }
        Console.WriteLine("a) Рік з найменшим номером: " + minYear);

        // b) всі весняні дати
        Console.WriteLine("b) Весняні дати:");
        foreach (var date in dates)
        {
            if (date.Month >= 3 && date.Month <= 5)
            {
                Console.WriteLine(date.ToString("dd.MM.yyyy"));
            }
        }

        // c) сама пізня дата
        DateTime latestDate = dates[0];
        foreach (var date in dates)
        {
            if (date > latestDate)
            {
                latestDate = date;
            }
        }
        Console.WriteLine("c) Сама пізня дата: " + latestDate.ToString("dd.MM.yyyy"));
    }
}
