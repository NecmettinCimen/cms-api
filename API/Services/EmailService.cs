using System;
using System.Collections.Concurrent;
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
    public class EmailManage
    {
        public static ConcurrentQueue<MailMessage> concurrentQueue = new ConcurrentQueue<MailMessage>();
        public static void AddEmailQueue(IConfiguration configuration, string subject, string body, bool isHtml = true, Attachment attachment = null)
        {
            var msg = new MailMessage(configuration["SqliteBackupService:MailMessage:FromMailAdress"], configuration["SqliteBackupService:MailMessage:ToMailAdress"], subject, body);
            msg.IsBodyHtml = isHtml;
            if (attachment != null)
                msg.Attachments.Add(attachment);

            concurrentQueue.Enqueue(msg);

        }
    }
    public class EmailService : IHostedService
    {

        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration configuration;

        public EmailService(
            ILogger<EmailService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailService Service running.");

            while (true)
            {
                MailMessage msg;
                while (EmailManage.concurrentQueue.TryDequeue(out msg))
                {
                    var smtpClient = new SmtpClient("smtp.yandex.ru", 587);
                    smtpClient.Credentials = new NetworkCredential(configuration["SqliteBackupService:NetworkCredential:UserName"], configuration["SqliteBackupService:NetworkCredential:Password"]);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(msg);
                    
                }
                await Task.Delay(1000*60,stoppingToken);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailService is stopping.");

            return Task.CompletedTask;
        }

    }
}