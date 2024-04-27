using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Program
{
    public static async Task Main()
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

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        Product product = JsonSerializer.Deserialize<Product>(response.Content!, options)!;
        // OR
        JsonNode data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
        
        // output result
        Console.WriteLine($"""
        --------------------
        json properties
        --------------------
        id:     {data["id"]}
        name:   {data["name"]}
        --------------------
        raw json data
        --------------------
        {data}
        """);
    }
}
//  --------------------
//  json properties
//  --------------------
//  id: 1
//  name: Commodore 64
//  --------------------
//  raw json data
//  --------------------
//  {
//    "id": 1,
//    "name": "Commodore 64"
//  }
