using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile1 = "D:\\КПНУ\\ООП\\Lab8\\ConsoleApp1\\f1.txt";
        string inputFile2 = "D:\\КПНУ\\ООП\\Lab8\\ConsoleApp1\\f2.txt";
        string helperFile = "D:\\КПНУ\\ООП\\Lab8\\ConsoleApp1\\h.txt";

        // Читаємо компоненти файлу f1 і записуємо їх у файл h
        ReadAndWriteToFile(inputFile1, helperFile);

        // Читаємо компоненти файлу f2 і записуємо їх у файл f1
        ReadAndWriteToFile(inputFile2, inputFile1);

        // Читаємо компоненти файлу h і записуємо їх у файл f2
        ReadAndWriteToFile(helperFile, inputFile2);

        // Видаляємо допоміжний файл
        File.Delete(helperFile);

        Console.WriteLine("Success");
    }

    static void ReadAndWriteToFile(string inputFile, string outputFile)
    {
        using (StreamReader reader = new StreamReader(inputFile))
        using (StreamWriter writer = new StreamWriter(outputFile, true)) // true для додавання до кінця файлу
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                writer.WriteLine(line);
            }
        }
    }
}
