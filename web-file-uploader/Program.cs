using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

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
                    webBuilder.UseRouting();
                    webBuilder.UseEndpoints(endpoints =>
                    {
                        // Endpoints for routing to the controller.
                        endpoints.MapControllerRoute(
                            name: "default",
                            PatternBuilder: "{controller=Home}/{action=Index}/{id?}");
                    });
                }).Build();
        
            await host.RunAsync();
        }
    }
    
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

        }
    }
}