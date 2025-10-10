// See https://aka.ms/new-console-template for more information
using ApiClientTest;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;

Console.WriteLine("Hello, World!");
HttpClient httpClient = new HttpClient();
var response = await httpClient.GetAsync("https://localhost:7285/products/3");
response.EnsureSuccessStatusCode();
if (response.IsSuccessStatusCode)
{
    var result = await response.Content.ReadAsStringAsync();

        var productList = JsonConvert.DeserializeObject<Product>(result);

    Console.WriteLine(productList.name );
    //foreach (var item in productList)
    //{
    //    Console.WriteLine($"{item.name} - {item.price}");
    //}
}