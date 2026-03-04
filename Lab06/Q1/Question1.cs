using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SystemProgramming.Lab06
{
    public static class Question1 
    {
        public static void Main(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args);

            // Cấu hình chạy như Windows Service
            builder = builder.UseWindowsService();

            builder = builder.ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });

            // Build Host
            IHost host = builder.Build();

            // Chạy Service
            host.Run();
        }
    }
}