
namespace AsyncAwait;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var contentLength = await GetUrlContentLengthAsync();
        Console.WriteLine("Length: " + contentLength);
        Console.WriteLine("thread count: {0}", ThreadPool.ThreadCount);
    }
    
    static async Task<int> GetUrlContentLengthAsync()
    {
        var client = new HttpClient();
    
        Task<string> getStringTask =
            client.GetStringAsync("https://learn.microsoft.com/dotnet");
    
        DoIndependentWork();
    
        string contents = await getStringTask;
    
        return contents.Length;
    }
    
    static void DoIndependentWork()
    {
        Console.WriteLine("Working...");
    }
}