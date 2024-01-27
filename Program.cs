using System;
using System.IO;

class Program
{
    // ���� ��� ��������� ����������� ������
    private static string loremIpsumText;

    static void Main()
    {
        LoadLoremIpsumText();  // ������������ ������ "Lorem ipsum" � �����

        while (true)
        {
            // ��������� ����
            Console.WriteLine("1. Display the number of words in the text \"Lorem ipsum\"");
            Console.WriteLine("2. Perform a mathematical operation");
            Console.WriteLine("0. Exit");

            // ���� ������ ����
            Console.Write("Enter the menu item number: ");
            int choice = int.Parse(Console.ReadLine());

            // ������� ������ �����������
            switch (choice)
            {
                case 1:
                    CountWordsInLoremIpsum();
                    break;
                case 2:
                    PerformMathOperation();
                    break;
                case 0:
                    Environment.Exit(0);  // ����� � ��������
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }
    }

    // ����� ��� ������������ ������ "Lorem ipsum" � �����
    private static void LoadLoremIpsumText()
    {
        try
        {
            // ������� ������ � ����� �� ���������� � ���
            loremIpsumText = File.ReadAllText("LoremIpsum.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the text: {ex.Message}");
        }
    }

    // ����� ��� ��������� ������� ��� � ����� "Lorem ipsum"
    private static void CountWordsInLoremIpsum()
    {
        // ������������ Split ��� ��������� ������ �� ����� �� ��������� ������� ���
        int wordCount = loremIpsumText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"The number of words in the text \"Lorem ipsum\": {wordCount}");
    }

    // ����� ��� ��������� ����������� ��������
    private static void PerformMathOperation()
    {
        Console.Write("Enter the expression to calculate: ");
        string expression = Console.ReadLine();

        try
        {
            // ������������ Eval ��� ���������� ������
            double result = Eval(expression);
            Console.WriteLine($"Calculation result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while evaluating the expression: {ex.Message}");
        }
    }

    // ����� Eval ��� ���������� ������������� ������
    private static double Eval(string expression)
    {
        var dataTable = new System.Data.DataTable();
        return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
    }
}
