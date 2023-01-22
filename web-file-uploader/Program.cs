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
                }).Build();

            await host.RunAsync();
        }
    }
    
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Register required services for the session state.
            // Session state allows you to store data in a per-user session. Provides a unique session ID.
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}