using System;
using SimpleAPIClient;

    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var apiClient = new SimpleApiClient();
            var apiService = new APIService();

            try
            {
                var advice = await apiClient.GetRandomAdvice();
                Console.WriteLine("Random Advice: " + advice);

                var response = await apiService.GET("https://api.adviceslip.com/advice");
                Console.WriteLine($"Response status code: {response.StatusCode}");
                Console.WriteLine($"Response message: {response.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

