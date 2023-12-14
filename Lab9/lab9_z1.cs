using System;

// Делегат для представлення математичної функції однієї змінної
public delegate double FunctionDelegate(double x);

// Клас для знаходження кореня рівняння методом простої ітерації
public class SimpleIterationSolver
{
    private FunctionDelegate function;  // Функція рівняння
    private FunctionDelegate phi;       // Функція ітерації

    // Конструктор класу
    public SimpleIterationSolver(FunctionDelegate function, FunctionDelegate phi)
    {
        // Перевірка на валідність вхідних параметрів
        this.function = function ?? throw new ArgumentNullException(nameof(function));
        this.phi = phi ?? throw new ArgumentNullException(nameof(phi));
    }

    // Метод для знаходження кореня рівняння
    public double Solve(double initialGuess, double tolerance, int maxIterations)
    {
        double currentGuess = initialGuess;

        // Ітерації методу простої ітерації
        for (int i = 0; i < maxIterations; i++)
        {
            double nextGuess = phi(currentGuess);

            // Перевірка збіжності до кореня з заданою точністю
            if (Math.Abs(nextGuess - currentGuess) < tolerance)
            {
                Console.WriteLine($"Результат методу простої ітерації: {nextGuess} (за {i + 1} ітерацій)");
                return nextGuess;
            }

            currentGuess = nextGuess;
        }

        // Викидання винятку, якщо не вдалося знайти корінь за заданою точністю і кількістю ітерацій
        throw new InvalidOperationException("Метод простої ітерації не збігся до кореня з заданою точністю за максимальну кількість ітерацій.");
    }
}

// Клас для тестування класу SimpleIterationSolver
class Program
{
    static void Main()
    {
        // Приклад використання класу SimpleIterationSolver для знаходження кореня рівняння x^2 - 3 = 0
        FunctionDelegate equation = x => x * x - 3;

        // Функція ітерації
        FunctionDelegate phiFunction = x => x - (x * x - 3) / (2 * x);

        SimpleIterationSolver solver = new SimpleIterationSolver(equation, phiFunction);

        double initialGuess = 1.0;
        double tolerance = 1e-6;
        int maxIterations = 100;

        try
        {
            double root = solver.Solve(initialGuess, tolerance, maxIterations);
            Console.WriteLine($"Знайдений корінь: {root}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.ReadLine();
    }
}
