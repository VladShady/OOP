using System;

interface ILamp
{
    string Type { get; set; }
    string Manufacturer { get; set; }
    int power { get; set; }
    string LightType { get; set; }
    int LightsCount { get; set; }

    void PrintInfo();
    void ChangePower(int newPower);
}

interface ICamera
{
    string Type { get; set; }
    string Manufacturer { get; set; }
    int LightSensitivity { get; set; }

    void PrintInfo();
    void ChangeSensitivity(int newSensitivity);
}

class PhotoStudio : ILamp, ICamera
{
    // Інтерфейс ILamp
    public string Type { get; set; }
    public string Manufacturer { get; set; }
    public int power { get; set; }
    public string LightType { get; set; }
    public int LightsCount { get; set; }

    public int LightSensitivity { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"Інформація про лампу: Тип - {Type}, Виробник - {Manufacturer}, Потужність - {power} люменів, Вид світла - {LightType}, Кількість - {LightsCount}");
    }

    public void ChangePower(int newPower)
    {
        power = newPower;
        Console.WriteLine($"Потужність змінено на {newPower} люменів");
    }

    public void ChangeSensitivity(int newSensitivity)
    {
        LightSensitivity = newSensitivity;
        Console.WriteLine($"Світлочутливість змінено на {newSensitivity}");
    }

    public void PrintAllInfo()
    {
        PrintInfo();
        Console.WriteLine($"Інформація про камеру: Тип - {Type}, Виробник - {Manufacturer}, Світлочутливість - {LightSensitivity}");
    }
}

class Program
{
    static void Main()
    {
        PhotoStudio studio1 = new PhotoStudio
        {
            Type = "Професійна",
            Manufacturer = "ABC123",
            power = 1000,
            LightType = "LED",
            LightsCount = 5,
            LightSensitivity = 200
        };

        PhotoStudio studio2 = new PhotoStudio
        {
            Type = "Аматорська",
            Manufacturer = "XYZ456",
            power = 500,
            LightType = "Флюоресцентне",
            LightsCount = 3,
            LightSensitivity = 100
        };

        Console.WriteLine("Фото студія 1:");
        studio1.PrintAllInfo();
        Console.WriteLine();

        Console.WriteLine("Фото студія 2:");
        studio2.PrintAllInfo();
        Console.WriteLine();

        studio1.ChangeSensitivity(250);

        Console.WriteLine("Фото студія 1 (після зміни світлочутливості):");
        studio1.PrintAllInfo();
    }
}
