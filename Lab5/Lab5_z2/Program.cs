using System;

public interface Printable
{
    void Print();
}

public class Book : Printable
{
    private string title;

    public Book(string title)
    {
        this.title = title;
    }

    public void Print()
    {
        Console.WriteLine("Книга: " + title);
    }

    public static void PrintBooks(Printable[] printable)
    {
        Console.WriteLine("Список книг:");
        foreach (Printable item in printable)
        {
            if (item is Book)
            {
                item.Print();
            }
        }
    }
}

public class Magazine : Printable
{
    private string title;

    public Magazine(string title)
    {
        this.title = title;
    }

    public void Print()
    {
        Console.WriteLine("Журнал: " + title);
    }

    public static void PrintMagazines(Printable[] printable)
    {
        Console.WriteLine("Список журналів:");
        foreach (Printable item in printable)
        {
            if (item is Magazine)
            {
                item.Print();
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Printable[] printableItems = new Printable[]
        {
            new Book("Книга 1"),
            new Magazine("Журнал 1"),
            new Book("Книга 2"),
            new Magazine("Журнал 2")
        };

        foreach (Printable item in printableItems)
        {
            item.Print();
        }

        Magazine.PrintMagazines(printableItems);

        Book.PrintBooks(printableItems);
    }
}
