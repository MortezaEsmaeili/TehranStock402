// See https://aka.ms/new-console-template for more information
using APITester;
using System.Text.Json;

Console.WriteLine("Hello, World!");

var client = new HttpClient();
string result =
    await client.GetStringAsync($"https://cdn.tsetmc.com/api/ClosingPrice/GetClosingPriceInfo/31447590411939048");
Root? root = JsonSerializer.Deserialize<Root>(result);

Console.WriteLine(result);
