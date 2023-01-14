using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cms_api.Services
{
    public class LoggerBackgroundService : IHostedService
    {

        public static int istelsayi = 0;
        public static int hatasayisi = 0;
        public static int kayitsayisi = 0;
        private readonly ILogger<LoggerBackgroundService> _logger;
        private readonly IConfiguration configuration;

        public LoggerBackgroundService(
            ILogger<LoggerBackgroundService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("LoggerBackgroundService running.");

// #if !DEBUG
            
//             while (true)
//             {
//                 try
//                 {
//                     var body = File.ReadAllText(".\\EmailTemplates\\cms-api-summary-api-template.html")
//             .Replace("zaman", DateTime.Now.ToString())
//             .Replace("istelsayi", istelsayi.ToString())
//             .Replace("hatasayisi", hatasayisi.ToString())
//             .Replace("kayitsayisi", kayitsayisi.ToString());

//                     EmailManage.AddEmailQueue(configuration, $"Cms Api Summary", body);
//                 }
//                 catch (Exception ex)
//                 {
//                     _logger.LogInformation(
//                         "LoggerBackgroundService is error. {ex}", ex);
//                 }

//             _logger.LogInformation(
//                 "LoggerBackgroundService is working. Time: {Time}", DateTime.Now);
            
//                 await Task.Delay(1000*60*60*12,stoppingToken);
//         }            
// #endif
            return Task.CompletedTask;

        }
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("LoggerBackgroundService is stopping.");

            return Task.CompletedTask;
        }
    }
}