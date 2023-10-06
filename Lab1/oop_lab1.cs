using System;
using System.Collections.Generic;

class Component
{
    public string Code { get; set; }
    public string ComponentType { get; set; }
    public double Nominal { get; set; }
    public int Quantity { get; set; }

    public Component()
    {
    }

    public Component(string code, string componentType, double nominal, int quantity)
    {
        Code = code;
        ComponentType = componentType;
        Nominal = nominal;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Позначення: {Code}, Тип: {ComponentType}, Номінал: {Nominal}, Кількість: {Quantity}";
    }
}

class ComponentInventory
{
    private List<Component> components = new List<Component>();

    public void AddComponent(Component component)
    {
        components.Add(component);
    }

    public bool RemoveComponent(string code)
    {
        Component componentToRemove = components.Find(c => c.Code == code);
        if (componentToRemove != null)
        {
            components.Remove(componentToRemove);
            return true;
        }
        return false;
    }

    public Component FindComponent(string code)
    {
        return components.Find(c => c.Code == code);
    }

    public override string ToString()
    {
        string result = "Відомість комплектуючих:\n";
        foreach (Component component in components)
        {
            result += component.ToString() + "\n";
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        ComponentInventory inventory = new ComponentInventory();

        Component component1 = new Component("RT-11-24", "R", 100000, 12);
        Component component2 = new Component("RT-11-24", "R", 50000, 10);
        Component component3 = new Component("CGU-12K", "C", 17.5, 3);

        inventory.AddComponent(component1);
        inventory.AddComponent(component2);
        inventory.AddComponent(component3);

        Console.WriteLine("Всі компоненти:");
        Console.WriteLine(inventory);

        string codeToFind = "RT-11-24";
        Component foundComponent = inventory.FindComponent(codeToFind);
        if (foundComponent != null)
        {
            Console.WriteLine($"Знайдено компонент за позначенням '{codeToFind}': {foundComponent}");
        }
        else
        {
            Console.WriteLine($"Компонент за позначенням '{codeToFind}' не знайдено");
        }

        string codeToRemove = "RT-11-24";
        if (inventory.RemoveComponent(codeToRemove))
        {
            Console.WriteLine($"Компонент за позначенням '{codeToRemove}' видалено");
        }
        else
        {
            Console.WriteLine($"Компонент за позначенням '{codeToRemove}' не знайдено");
        }

        Console.WriteLine("Оновлена відомість комплектуючих:");
        Console.WriteLine(inventory);
    }
}
