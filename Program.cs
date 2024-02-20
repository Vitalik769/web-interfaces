using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting demonstration of Thread class...");
        ThreadFirst();
        Console.WriteLine("\nStarting another demonstration of Thread class...");
        ThreadSecond();
        Console.WriteLine("\nStarting yet another demonstration of Thread class...");
        ThreadThird();

        Console.WriteLine("\nStarting demonstration of Async - Await...");
        AsyncAwaitFirst();
        Console.WriteLine("\nStarting another demonstration of Async - Await...");
        AsyncAwaitSecond();
        Console.WriteLine("\nStarting yet another demonstration of Async - Await...");
        AsyncAwaitThird();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void ThreadFirst()
    {
        // Метод ThreadFirst демонструє сортування масиву
        int[] array = { 5, 4, 3, 2, 1 };
        Thread thread1 = new Thread(() =>
        {
            Console.WriteLine("Thread 1 is sorting the array...");
            Array.Sort(array);
            Console.WriteLine("Thread 1 sorted the array.");
            foreach (int num in array)
            {
                Console.WriteLine(num);
            }
        });

        thread1.Start();
        thread1.Join();

        Console.WriteLine("ThreadFirst method is done.");
    }

    static void ThreadSecond()
    {
        // Метод ThreadSecond демонструє виведення довільного повідомлення
        Thread thread2 = new Thread(() =>
        {
            Console.WriteLine("Thread 2 is printing a message...");
            Console.WriteLine("Hello from Thread 2!");
        });

        thread2.Start();
        thread2.Join();

        Console.WriteLine("ThreadSecond method is done.");
    }

    static void ThreadThird()
    {
        // Метод ThreadThird демонструє виконання математичних обчислень
        Thread thread3 = new Thread(() =>
        {
            Console.WriteLine("Thread 3 is performing some calculations...");
            int result = 0;
            for (int i = 1; i <= 100; i++)
            {
                result += i;
            }
            Console.WriteLine($"Thread 3 calculated the result: {result}");
        });

        thread3.Start();
        thread3.Join();

        Console.WriteLine("ThreadThird method is done.");
    }

    static async void AsyncAwaitFirst()
    {
        // Метод AsyncAwaitFirst демонструє асинхронне завдання з обробкою файлів
        Task task1 = Task.Run(async () =>
        {
            Console.WriteLine("Task 1 is processing files asynchronously...");
            await Task.Delay(2000);
            Console.WriteLine("Task 1 finished processing files.");
        });

        await task1;

        Console.WriteLine("AsyncAwaitFirst method is done.");
    }

    static async void AsyncAwaitSecond()
    {
        await Task.Run(() =>
        {
            int result = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                result += i;
            }
            Console.WriteLine("AsyncAwaitFirst completed with result: " + result);
        });
    }

    static async void AsyncAwaitThird()
    {
        Console.WriteLine("Starting AsyncAwaitThird");
        string userInput = await GetUserInputAsync();
        Console.WriteLine("User entered: " + userInput);
        Console.WriteLine("AsyncAwaitThird completed");
    }

    static async Task<string> GetUserInputAsync()
    {
        Console.Write("Enter your input: ");
        return await Task.Run(() => Console.ReadLine());
    }
}
