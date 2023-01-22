namespace web_file_uploader
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Configure the host for the application.
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specify the startup class for the application.
                    // .NET 6 removed the need for the 'Startup.cs' class. You can use the 'UseStartup' method to configure the middleware pipeline.
                    webBuilder.UseStartup<Startup>();
                })
                .Build();
        
            await host.RunAsync();
        }
    }
}