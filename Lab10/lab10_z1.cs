using System;
using System.Collections.Generic;

public class CharSet
{
    private HashSet<char> set;

    // Конструктор за замовчуванням
    public CharSet()
    {
        set = new HashSet<char>();
    }

    // Перенавантаження оператору "+" для додавання елементу в множину
    public static CharSet operator +(CharSet charSet, char element)
    {
        charSet.Add(element);
        return charSet;
    }

    // Перенавантаження оператору "+" для об'єднання множин
    public static CharSet operator +(CharSet set1, CharSet set2)
    {
        CharSet result = new CharSet();
        result.set.UnionWith(set1.set);
        result.set.UnionWith(set2.set);
        return result;
    }

    // Перенавантаження оператору "==" для порівняння множин на рівність
    public static bool operator ==(CharSet set1, CharSet set2)
    {
        return set1.set.SetEquals(set2.set);
    }

    // Перенавантаження оператору "!=" для порівняння множин на нерівність
    public static bool operator !=(CharSet set1, CharSet set2)
    {
        return !(set1 == set2);
    }

    // Додати елемент в множину
    public void Add(char element)
    {
        set.Add(element);
    }

    // Перевизначення методу Equals для порівняння об'єктів множин
    public override bool Equals(object obj)
    {
        if (obj is CharSet)
        {
            CharSet otherSet = (CharSet)obj;
            return this == otherSet;
        }

        return false;
    }

    // Перевизначення методу GetHashCode для використання у хеш-таблицях
    public override int GetHashCode()
    {
        return set.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        CharSet set1 = new CharSet();
        set1.Add('a');
        set1.Add('b');

        CharSet set2 = new CharSet();
        set2.Add('b');
        set2.Add('a');

        CharSet set3 = set1 + 'c'; // Додавання елементу
        CharSet set4 = set1 + set2; // Об'єднання множин

        Console.WriteLine("set1 == set2: " + (set1 == set2)); // Порівняння на рівність
        Console.WriteLine("set1 == set3: " + (set1 == set3));
        Console.WriteLine("set1 == set4: " + (set1 == set4));
    }
}
