using System;
using System.Collections.Generic;

class Component : IComparable<Component>
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

    public int CompareTo(Component other)
    {
        if (other == null)
            return 1;
        return Code.CompareTo(other.Code);
    }
}

class ComponentInventory<T> where T : IComparable<T>
{
    private List<T> components = new List<T>();

    public void AddComponent(T component)
    {
        components.Add(component);
    }

    public bool RemoveComponent(string code)
    {
        T componentToRemove = components.Find(c => c is Component comp && comp.Code == code);
        if (componentToRemove != null)
        {
            components.Remove(componentToRemove);
            return true;
        }
        return false;
    }

    public T FindComponent(string code)
    {
        return components.Find(c => c is Component comp && comp.Code == code);
    }

    public void SortComponents()
    {
        components.Sort();
    }

    public override string ToString()
    {
        string result = "Відомість комплектуючих:\n";
        foreach (T component in components)
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
        ComponentInventory<Component> inventory1 = new ComponentInventory<Component>();
        ComponentInventory<Component> inventory2 = new ComponentInventory<Component>();

        Component component1 = new Component("RT-11-24", "R", 100000, 12);
        Component component2 = new Component("RT-11-24", "R", 50000, 10);
        Component component3 = new Component("CGU-12K", "C", 17.5, 3);

        inventory1.AddComponent(component1);
        inventory1.AddComponent(component2);
        inventory2.AddComponent(component3);

        Console.WriteLine("Перша відомість комплектуючих:");
        Console.WriteLine(inventory1);

        Console.WriteLine("Друга відомість комплектуючих:");
        Console.WriteLine(inventory2);

        // Додавання інших компонентів
        Component component4 = new Component("RT-11-25", "R", 75000, 8);
        Component component5 = new Component("CGU-12K", "C", 22.5, 5);

        inventory1.AddComponent(component4);
        inventory2.AddComponent(component5);

        Console.WriteLine("Оновлена перша відомість комплектуючих:");
        inventory1.SortComponents();
        Console.WriteLine(inventory1);

        Console.WriteLine("Оновлена друга відомість комплектуючих:");
        inventory2.SortComponents();
        Console.WriteLine(inventory2);
    }
}
