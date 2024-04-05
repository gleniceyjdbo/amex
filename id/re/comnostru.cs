using System;
using System.Net.Http;

class Program
{
    static void Main()
    {
        // Initialize a new instance of HttpClient
        using (HttpClient client = new HttpClient())
        {
            // Set the timeout for the request to 5 seconds
            client.Timeout = TimeSpan.FromMilliseconds(5000);

            try
            {
                // Send a GET request to the specified Uri as an asynchronous operation
                HttpResponseMessage response = client.GetAsync("http://example.com").Result;

                // Ensure we received a successful response
                if (response.IsSuccessStatusCode)
                {
                    // Process the response
                    Console.WriteLine("Request succeeded.");
                    // TODO: Add logic to handle the response content
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                // Handle any exceptions that occurred during the request
                Console.WriteLine($"Request failed: {e.Message}");
            }
            catch (OperationCanceledException e)
            {
                // Handle timeout exceptions
                Console.WriteLine($"Request timed out: {e.Message}");
            }
        }
    }
}
