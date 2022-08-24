using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NET6ConsoleAPPWithDI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var hostBuilder = CreateHostBuilder(args);;
                var host = hostBuilder.Build();
                var provider = host.Services;

                var logger = provider.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("App starts......");

                //set appsettings.json COPY ALWAYS
                var config = provider.GetRequiredService<IConfiguration>();
                var appName = config.GetValue<string>("AppInfo:Name");
                logger.LogInformation($"App name is {appName}");

                var myService = provider.GetRequiredService<IMyService>();
                myService.Welcome();

                var count = await myService.GetSomethingFromDb();
                logger.LogInformation($"Count is {count}");

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
            var hostBuilder = Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureDelegate);

            return hostBuilder;
        }

        private static void ConfigureDelegate(HostBuilderContext hostContext, IServiceCollection services)
        {
            services
                .AddSingleton<IMyRepository, MyRepository>()
                .AddSingleton<IMyService,MyService>()
                .AddLogging(loggingBuilder => loggingBuilder.AddConsole());
        }

    }
}