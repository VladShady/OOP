using System;

// Визначення власного класу винятків для тривалості музичного твору
class TryvalistException : Exception
{
    public TryvalistException(string message) : base(message)
    {
    }
}

// Визначення власного класу винятків для назви музичного твору
class NazvaException : Exception
{
    public NazvaException(string message) : base(message)
    {
    }
}

// Основний клас, що представляє музичний твір
class MusicPiece
{
    private string title;
    private int duration;

    // Властивість для назви музичного твору з перевіркою на порожній рядок
    public string Title
    {
        get => title;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NazvaException("Nazva cannot be null or empty.");
            }
            title = value;
        }
    }

    // Властивість для тривалості музичного твору з перевіркою на значення менше або рівне нулю
    public int Duration
    {
        get => duration;
        set
        {
            if (value <= 0)
            {
                throw new TryvalistException("Duration must be greater than zero.");
            }
            duration = value;
        }
    }

    // Конструктор класу MusicPiece
    public MusicPiece(string title, int duration)
    {
        try
        {
            // Встановлення назви та тривалості, обробка винятків
            Title = title;
            Duration = duration;
        }
        catch (NazvaException ex)
        {
            // Обробка винятку для назви музичного твору
            Console.WriteLine($"Cannot create music piece - {ex.Message}");
            // Retry with a default value or handle it as needed.
            Title = "Unknown";
        }
        catch (TryvalistException ex)
        {
            // Обробка винятку для тривалості музичного твору
            Console.WriteLine($"Cannot create music piece - {ex.Message}");
            // Retry with a default value or handle it as needed.
            Duration = 1;
        }
        catch (Exception ex)
        {
            // Обробка неочікуваного винятку
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    // Метод для генерації опису музичного твору
    public string GenerateDescription()
    {
        try
        {
            return $"Music Piece: {Title}\nDuration: {Duration} minutes\n";
        }
        catch (NazvaException ex)
        {
            // Обробка винятку для назви музичного твору під час генерації опису
            return $"Error generating description: {ex.Message}\n";
        }
        catch (TryvalistException ex)
        {
            // Обробка винятку для тривалості музичного твору під час генерації опису
            return $"Error generating description: {ex.Message}\n";
        }
        catch (Exception ex)
        {
            // Обробка неочікуваного винятку під час генерації опису
            return $"Unexpected error: {ex.Message}\n";
        }
    }
}

// Клас для демонстрації використання власних класів винятків
class Program
{
    static void Main()
    {
        try
        {
            // Приклад використання
            MusicPiece invalidMusicPiece = new MusicPiece("", 0); // Викличе виняток NazvaException та TryvalistException
            Console.WriteLine(invalidMusicPiece.GenerateDescription());
        }
        catch (NazvaException ex)
        {
            // Обробка винятку для назви музичного твору в основному методі
            Console.WriteLine($"Error in Main(): {ex.Message}");
        }
        catch (TryvalistException ex)
        {
            // Обробка винятку для тривалості музичного твору в основному методі
            Console.WriteLine($"Error in Main(): {ex.Message}");
        }
        catch (Exception ex)
        {
            // Обробка неочікуваного винятку в основному методі
            Console.WriteLine($"Unexpected error in Main(): {ex.Message}");
        }
    }
}
