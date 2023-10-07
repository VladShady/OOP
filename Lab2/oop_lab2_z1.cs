using System;
using System.Linq;

public static class ArrayExtensions
{
    public static void PrintEvenOdd(this int[] array)
    {
        var evenNumbers = array.Where(x => x % 2 == 0);
        var oddNumbers = array.Where(x => x % 2 != 0);

        Console.WriteLine("Парні елементи:");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("Непарні елементи:");
        foreach (var number in oddNumbers)
        {
            Console.WriteLine(number);
        }
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        numbers.PrintEvenOdd();
    }
}
