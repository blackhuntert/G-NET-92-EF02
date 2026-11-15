namespace EventHub
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using EventHubDbContext context = new EventHubDbContext();
            await context.Database.EnsureCreatedAsync();
        }
    }
}
