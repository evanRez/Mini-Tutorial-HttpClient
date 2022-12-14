using System.Text.Json;
using WebAPIClient;

internal class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        await ProcessRepositories();
    }

    private static async Task ProcessRepositories()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
        );
        client.DefaultRequestHeaders.Add("User-Agent", ".Net Foundation Repository Reporter");

        var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

        foreach (var repo in repositories)
            Console.WriteLine(repo.Name);
    }
}