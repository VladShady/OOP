using System;

class Program
{
    struct Note
    {
        public string Name;
        public string PhoneNumber;
        public string BirthDate;
    }

    static void Main()
    {
        Note[] arr = new Note[4];

        // Введення даних про контакти
        for (int i = 0; i < 4; i++)
        {
            Console.Write("Введіть ім'я та прізвище: ");
            arr[i].Name = Console.ReadLine();

            Console.Write("Введіть номер телефону: ");
            arr[i].PhoneNumber = Console.ReadLine();

            Console.Write("Введіть дату народження: ");
            arr[i].BirthDate = Console.ReadLine();
        }

        // Сортування масиву по першим трьом цифрам телефону
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3 - i; j++)
            {
                int phone1 = int.Parse(arr[j].PhoneNumber.Substring(0, 3));
                int phone2 = int.Parse(arr[j + 1].PhoneNumber.Substring(0, 3));

                if (phone1 > phone2)
                {
                    Note temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

        // Відсортований за номером телефону список
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("Ім'я: {0}", arr[i].Name);
            Console.WriteLine("Номер телефону: {0}", arr[i].PhoneNumber);
            Console.WriteLine("Дата народження: {0}", arr[i].BirthDate);
        }

        // Пошук та виведення інформації
        Console.Write("Введіть прізвище для пошуку: ");
        string searchPerson = Console.ReadLine();
        bool found = false;

        Console.WriteLine($"Інформація про персону {searchPerson}:");

        for (int i = 0; i < 4; i++)
        {
            if (string.Equals(arr[i].Name, searchPerson, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Ім'я та прізвище: {arr[i].Name}");
                Console.WriteLine($"Дата народження: {arr[i].BirthDate}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Персону з прізвищем {searchPerson} не знайдено.");
        }
    }
}
