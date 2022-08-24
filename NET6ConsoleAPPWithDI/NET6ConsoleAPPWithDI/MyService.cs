
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NET6ConsoleAPPWithDI
{
    public class MyService: IMyService
    {
        private readonly ILogger<MyService> _logger;
        private readonly IConfiguration _configuration;

        public MyService(ILogger<MyService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public void Welcome()
        {
            var message = _configuration.GetValue<string>("AppInfo:Messages:Welcome");
            _logger.LogInformation($"Hello World, {message}");
        }
    }
}
