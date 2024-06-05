using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    HttpClient client = new HttpClient();
    try
    {
        Console.WriteLine("Using Selenium.WebDriver: " + Assembly.GetAssembly(typeof(HttpClient)).GetName().Version.ToString());
        // Fetch HTML from google.com and return it
        HttpResponseMessage response = client.GetAsync("http://www.google.com").Result;
        response.EnsureSuccessStatusCode();
        string responseBody = response.Content.ReadAsStringAsync().Result;
        return responseBody;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
    }

    return "Hello World2!";
});

app.Run();
