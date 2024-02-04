using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace XamarinAPIExample
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();
        // Call the methods to get data from various APIs
        public static async Task Main(string[] args)
        {
            await GetWeatherData();
            await GetRandomQuote();
            await GetCurrencyExchangeRate();
            await GetCatBreeds();
            await GetGitHubUserInfo();
        }
        //Method for getting weather data
        public static async Task GetWeatherData()
        {
            string apiUrl = "https://api.weatherapi.com/v1/current.json?key=030a5033ffe746588c5130648240402&q=London";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);
                string temperature = data.current.temp_c;
                Console.WriteLine($"Current temperature in London: {temperature}°C");
            }
        }
        // Method to get a random quote
        public static async Task GetRandomQuote()
        {
            string apiUrl = "https://api.quotable.io/random";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);
                string quote = data.content;
                Console.WriteLine($"Random Quote: {quote}");
            }
        }
        // Method for obtaining the exchange rate
        public static async Task GetCurrencyExchangeRate()
        {
            string apiUrl = "https://api.exchangerate-api.com/v4/latest/USD";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);
                double exchangeRate = data.rates.EUR;
                Console.WriteLine($"1 USD to EUR: {exchangeRate}");
            }
        }
        // Method to get a list of cat breeds (limited to first 10)
        public static async Task GetCatBreeds()
        {
            string apiUrl = "https://api.thecatapi.com/v1/breeds";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);

                int numberOfBreedsToShow = 10; // Change this number if you want to display more or fewer breeds

                for (int i = 0; i < numberOfBreedsToShow; i++)
                {
                    string breedName = data[i].name;
                    Console.WriteLine($"Cat Breed: {breedName}");
                }
            }
        }

        // Method to retrieve information about a GitHub user
        public static async Task GetGitHubUserInfo()
        {
            string apiUrl = "https://api.github.com/users/Vitalik769";
            client.DefaultRequestHeaders.UserAgent.ParseAdd("SystemAminimtratorsNotebook");
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);
                string username = data.login;
                string bio = data.bio;
                Console.WriteLine($"GitHub User: {username}, Bio: {bio}");
            }
        }
    }
}

