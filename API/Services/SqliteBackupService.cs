using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cms_api.Services
{
    public class SqliteBackupService : IHostedService, IDisposable
    {

        public static int istelsayi = 0;
        public static int hatasayisi = 0;
        public static int kayitsayisi = 0;
        private readonly ILogger<SqliteBackupService> _logger;
        private readonly IConfiguration configuration;
        private Timer _timer;

        public SqliteBackupService(
            ILogger<SqliteBackupService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SqliteBackupService running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromHours(12));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            if (istelsayi != 0 || hatasayisi != 0 || kayitsayisi != 0)
            {
                try
                {
                    var body = File.ReadAllText(".\\EmailTemplates\\cms-api-summary-api-template.html")
            .Replace("zaman", DateTime.Now.ToString())
            .Replace("istelsayi", istelsayi.ToString())
            .Replace("hatasayisi", hatasayisi.ToString())
            .Replace("kayitsayisi", kayitsayisi.ToString());

                    EmailManage.AddEmailQueue(configuration, $"Cms Api Summary", body, attachment: new Attachment(".\\CmsContext.db"));
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(
                        "SqliteBackupService is error. {ex}", ex);
                }
            }

            _logger.LogInformation(
                "SqliteBackupService is working. Time: {Time}", DateTime.Now);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SqliteBackupService is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}