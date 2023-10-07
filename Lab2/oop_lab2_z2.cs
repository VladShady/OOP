using System;

class Component
{
    public string Code { get; set; }
    public string ComponentType { get; set; }
    public double Nominal { get; set; }
    public int Quantity { get; set; }

    private static int objectCount = 0;

    public Component(string code, string componentType, double nominal, int quantity)
    {
        Code = code;
        ComponentType = componentType;
        Nominal = nominal;
        Quantity = quantity;
        objectCount++;
    }

    public static Component[] FindComponentsByType(Component[] components, string componentType)
    {
        return Array.FindAll(components, c => c.ComponentType == componentType);
    }

    public static int GetObjectCount()
    {
        return objectCount;
    }

    public override string ToString()
    {
        return $"Позначення: {Code}, Тип: {ComponentType}, Номінал: {Nominal}, Кількість: {Quantity}";
    }
}

class Program
{
    static void Main()
    {
        Component[] components = new Component[]
        {
            new Component("RT-11-24", "R", 100000, 12),
            new Component("RT-11-24", "R", 50000, 10),
            new Component("CGU-12K", "C", 17.5, 3),
            new Component("XYZ-123", "R", 75000, 8),
            new Component("ABC-789", "C", 12.5, 5),
            new Component("LMN-456", "R", 30000, 6),
            new Component("PQR-999", "C", 9.0, 7),
            new Component("JKL-777", "R", 60000, 9),
            new Component("DEF-555", "C", 15.0, 4),
            new Component("UVW-888", "R", 45000, 11)
        };

        Console.WriteLine("Всі компоненти:");
        foreach (var component in components)
        {
            Console.WriteLine(component);
        }

        string searchComponentType = "R";
        Component[] foundComponents = Component.FindComponentsByType(components, searchComponentType);
        Console.WriteLine($"Знайдені компоненти типу '{searchComponentType}':");
        foreach (var component in foundComponents)
        {
            Console.WriteLine(component);
        }

        int objectCount = Component.GetObjectCount();
        int maxCount = 15;
        int minCount = 5; 

        if (objectCount > maxCount)
        {
            Console.WriteLine("Кількість об'єктів перевищує граничне значення 1");
        }
        else if (objectCount < minCount)
        {
            Console.WriteLine("Кількість об'єктів менше граничного значення 2");
        }
    }
}
