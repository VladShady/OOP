using System;

public enum ClothingSize
{
    XXS, XS, S, M, L
}

interface IMensClothing
{
    void DressMan();
}

interface IWomensClothing
{
    void DressWoman();
}

abstract class Clothing
{
    protected ClothingSize size;
    protected double price;
    protected string color;

    public Clothing(ClothingSize size, double price, string color)
    {
        this.size = size;
        this.price = price;
        this.color = color;
    }

    public abstract string Description();
}

class TShirt : Clothing, IMensClothing, IWomensClothing
{
    public TShirt(ClothingSize size, double price, string color)
        : base(size, price, color)
    {
    }

    public override string Description()
    {
        return "Футболка: Розмір " + size + ", Колір " + color + ", Вартість " + price + " євро";
    }

    public void DressMan()
    {
        Console.WriteLine("Чоловік одягнув футболку.");
    }

    public void DressWoman()
    {
        Console.WriteLine("Жінка одягнула футболку.");
    }
}

class Pants : Clothing, IMensClothing, IWomensClothing
{
    public Pants(ClothingSize size, double price, string color)
        : base(size, price, color)
    {
    }

    public override string Description()
    {
        return "Штани: Розмір " + size + ", Колір " + color + ", Вартість " + price + " євро";
    }

    public void DressMan()
    {
        Console.WriteLine("Чоловік одягнув штани.");
    }

    public void DressWoman()
    {
        Console.WriteLine("Жінка одягнула штани.");
    }
}

class Skirt : Clothing, IWomensClothing
{
    public Skirt(ClothingSize size, double price, string color)
        : base(size, price, color)
    {
    }

    public override string Description()
    {
        return "Спідниця: Розмір " + size + ", Колір " + color + ", Вартість " + price + " євро";
    }

    public void DressWoman()
    {
        Console.WriteLine("Жінка одягнула спідницю.");
    }
}

class Tie : Clothing, IMensClothing
{
    public Tie(ClothingSize size, double price, string color)
        : base(size, price, color)
    {
    }

    public override string Description()
    {
        return "Краватка: Розмір " + size + ", Колір " + color + ", Вартість " + price + " євро";
    }

    public void DressMan()
    {
        Console.WriteLine("Чоловік одягнув краватку.");
    }
}

class Shop
{
    private ClothingSize[] clothingSizes;
    private int euroSize;

    public Shop(ClothingSize[] clothingSizes, int euroSize)
    {
        this.clothingSizes = clothingSizes;
        this.euroSize = euroSize;
    }

    public string GetDescription()
    {
        if (euroSize == 32)
        {
            return "Дитячий розмір";
        }
        else
        {
            return "Дорослий розмір";
        }
    }
}

class Atelier
{
    public void DressWoman(IWomensClothing[] womensClothing)
    {
        Console.WriteLine("Одягнути жінку:");
        foreach (var clothing in womensClothing)
        {
            clothing.DressWoman();
        }
    }

    public void DressMan(IMensClothing[] mensClothing)
    {
        Console.WriteLine("Одягнути чоловіка:");
        foreach (var clothing in mensClothing)
        {
            clothing.DressMan();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClothingSize[] clothingSizes = { ClothingSize.XXS, ClothingSize.XS, ClothingSize.S, ClothingSize.M, ClothingSize.L };
        Shop shop = new Shop(clothingSizes, 36);

        TShirt tShirt = new TShirt(ClothingSize.M, 20.0, "Чорний");
        Pants pants = new Pants(ClothingSize.L, 40.0, "Сірий");
        Skirt skirt = new Skirt(ClothingSize.S, 30.0, "Рожевий");
        Tie tie = new Tie(ClothingSize.M, 15.0, "Синій");

        IWomensClothing[] womensClothing = { tShirt, skirt };
        IMensClothing[] mensClothing = { tShirt, pants, tie };

        Atelier atelier = new Atelier();
        atelier.DressWoman(womensClothing);
        atelier.DressMan(mensClothing);

        Console.WriteLine("Розмір одягу в магазині: " + shop.GetDescription());

        Console.ReadLine();
    }
}
