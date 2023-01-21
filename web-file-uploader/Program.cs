namespace web_file_uploader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "This is a test to see if the repository was created properly.");

            app.Run();
        }
    }
}