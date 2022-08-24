using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NET6ConsoleAPPWithDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var hostBuilder = CreateHostBuilder(args);;
                var host = hostBuilder.Build();
                var provider = host.Services;

                var logger = provider.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("App starts......");


                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());
            });

            return hostBuilder;
        }

    }
}