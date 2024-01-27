using System;
using System.IO;

class Program
{
    // Поле для зберігання початкового тексту
    private static string loremIpsumText;

    static void Main()
    {
        LoadLoremIpsumText();  // Завантаження тексту "Lorem ipsum" з файлу

        while (true)
        {
            // Виведення меню
            Console.WriteLine("1. Display the number of words in the text \"Lorem ipsum\"");
            Console.WriteLine("2. Perform a mathematical operation");
            Console.WriteLine("0. Exit");

            // Вибір пункту меню
            Console.Write("Enter the menu item number: ");
            int choice = int.Parse(Console.ReadLine());

            // Обробка вибору користувача
            switch (choice)
            {
                case 1:
                    CountWordsInLoremIpsum();
                    break;
                case 2:
                    PerformMathOperation();
                    break;
                case 0:
                    Environment.Exit(0);  // Вихід з програми
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }
    }

    // Метод для завантаження тексту "Lorem ipsum" з файлу
    private static void LoadLoremIpsumText()
    {
        try
        {
            // Читання тексту з файлу та збереження у полі
            loremIpsumText = File.ReadAllText("LoremIpsum.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the text: {ex.Message}");
        }
    }

    // Метод для виведення кількості слів у тексті "Lorem ipsum"
    private static void CountWordsInLoremIpsum()
    {
        // Використання Split для розділення тексту на слова та отримання кількості слів
        int wordCount = loremIpsumText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"The number of words in the text \"Lorem ipsum\": {wordCount}");
    }

    // Метод для виконання математичної операції
    private static void PerformMathOperation()
    {
        Console.Write("Enter the expression to calculate: ");
        string expression = Console.ReadLine();

        try
        {
            // Використання Eval для обчислення виразу
            double result = Eval(expression);
            Console.WriteLine($"Calculation result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while evaluating the expression: {ex.Message}");
        }
    }

    // Метод Eval для обчислення математичного виразу
    private static double Eval(string expression)
    {
        var dataTable = new System.Data.DataTable();
        return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
    }
}
