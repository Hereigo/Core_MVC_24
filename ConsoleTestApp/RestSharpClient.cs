using System.Text.Json;
using System.Text.Json.Nodes;
using RestSharp;

namespace ConsoleTestApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RestSharpClient
    {
        public static async Task RunTest()
        {
            // send GET request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");

            var request = new RestRequest("products/1");
            request.AddHeader("Authorization", "Bearer my-token");
            request.AddHeader("My-Custom-Header", "foobar");

            var response = await client.ExecuteGetAsync(request);

            // Error handling:
            if (!response.IsSuccessful)
            {
                Console.WriteLine($"ERROR: {response.ErrorException?.Message}");
                return;
            }

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Product product = JsonSerializer.Deserialize<Product>(response.Content!, options)!;
            // OR
            JsonNode data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;

            Console.WriteLine($"""
                -----------------------
                json properties :
                -----------------------
                id:     {product.Id}
                name:   {data["name"]}
                -----------------------
                raw json data :
                -----------------------
                {data}
                -----------------------
                """);
            //  -----------------------
            //  raw json data
            //  -----------------------
            //  {
            //    "id": 1,
            //    "name": "Commodore 64"
            //  }
        }
    }
}
