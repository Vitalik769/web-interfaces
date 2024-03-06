using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleAPIClient
{
    public class SimpleApiClient
    {
        private readonly HttpClient _httpClient;

        // Constructor of the SimpleApiClient class, initializes the HttpClient and sets the base address for requests.
        public SimpleApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.adviceslip.com/");
        }

        // A method to get a random tip.
        public async Task<string> GetRandomAdvice()
        {
            // We send a GET request to the address "advice".
            var response = await _httpClient.GetAsync("advice");
            // Check if the response status is successful.
            response.EnsureSuccessStatusCode();
            // Read and return the content of the response as a string.
            return await response.Content.ReadAsStringAsync();
        }
    }
}
