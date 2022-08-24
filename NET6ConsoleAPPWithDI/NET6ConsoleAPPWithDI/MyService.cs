using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NET6ConsoleAPPWithDI
{
    public class MyService: IMyService
    {
        private readonly ILogger<MyService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMyRepository _myRepository;

        public MyService(ILogger<MyService> logger, IConfiguration configuration, IMyRepository myRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _myRepository = myRepository;
        }
        public void Welcome()
        {
            var message = _configuration.GetValue<string>("AppInfo:Messages:Welcome");
            _logger.LogInformation($"Hello World, {message}");
        }

        public async Task<int> GetSomethingFromDb()
        {
            return await _myRepository.GetSomethingFromDb();
        }
    }
}
