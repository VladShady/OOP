using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть рядок: ");
        string inputString = Console.ReadLine();

        Console.Write("Введіть позицію, з якої почати заміну: ");
        int startPosition = int.Parse(Console.ReadLine());

        string modifiedString = ReplaceOnesAndZeros(inputString, startPosition);

        Console.WriteLine("Модифікований рядок: " + modifiedString);
    }

    static string ReplaceOnesAndZeros(string input, int startPosition)
    {
        char[] charArray = input.ToCharArray();

        for (int i = startPosition; i < charArray.Length; i++)
        {
            if (charArray[i] == '0')
            {
                charArray[i] = '1';
            }
            else if (charArray[i] == '1')
            {
                charArray[i] = '0';
            }
        }

        return new string(charArray);
    }
}
