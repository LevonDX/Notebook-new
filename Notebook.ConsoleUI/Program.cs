using Newtonsoft.Json;
using Notebook.Shared.Models;

namespace Notebook.ConsoleUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7126/api/");

            string getRecordsURL = "record/list";

            string responseStr = await client.GetStringAsync(getRecordsURL);

            JsonSerializer serializer = new JsonSerializer();
            List<Record>? records = serializer.Deserialize<List<Record>>(new JsonTextReader(new StringReader(responseStr)));

            records?.ForEach(r => Console.WriteLine(r));
        }
    }
}