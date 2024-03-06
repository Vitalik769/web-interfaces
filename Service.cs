using System; 
using System.Net;
using System.Net.Http; 
using System.Threading.Tasks; 

public class APIService
{
    private readonly HttpClient _httpClient; // Private field to store an instance of HttpClient.

    // Constructor of the APIService class, initializes an instance of HttpClient.
    public APIService()
    {
        _httpClient = new HttpClient();
    }

    // Method for performing an HTTP GET request to the specified URL.
    public async Task<APIResponse<string>> GET(string url)
    {
        var response = new APIResponse<string>(); // Creating a new instance of the APIResponse class to represent the server response.

        try
        {
            var httpResponse = await _httpClient.GetAsync(url); // Performing an asynchronous GET request to the specified URL.
            response.StatusCode = httpResponse.StatusCode; // Storing the HTTP status code of the response in the APIResponse instance.
            response.Message = httpResponse.ReasonPhrase; // Storing the server message in the APIResponse instance.
            response.Data.Add(await httpResponse.Content.ReadAsStringAsync()); // Storing the response content in the APIResponse instance.
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError; // Handling the exception and storing the status code 500 in the APIResponse instance.
            response.Message = ex.Message; // Storing the error message in the APIResponse instance.
        }

        return response; // Returning the APIResponse object.
    }

    // Method for performing an HTTP POST request to the specified URL with content.
    public async Task<APIResponse<string>> POST(string url, HttpContent content)
    {
        var response = new APIResponse<string>(); // Creating a new instance of the APIResponse class to represent the server response.

        try
        {
            var httpResponse = await _httpClient.PostAsync(url, content); // Performing an asynchronous POST request to the specified URL with content.
            response.StatusCode = httpResponse.StatusCode; // Storing the HTTP status code of the response in the APIResponse instance.
            response.Message = httpResponse.ReasonPhrase; // Storing the server message in the APIResponse instance.
            response.Data.Add(await httpResponse.Content.ReadAsStringAsync()); // Storing the response content in the APIResponse instance.
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError; // Handling the exception and storing the status code 500 in the APIResponse instance.
            response.Message = ex.Message; // Storing the error message in the APIResponse instance.
        }

        return response; // Returning the APIResponse object.
    }
}
