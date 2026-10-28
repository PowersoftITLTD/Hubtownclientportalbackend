using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Services
{
    public class SendGridService : ISendService
    {
        private readonly IConfiguration _configuration;

        public SendGridService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, CancellationToken cancellationToken = default)
        {
            try
            {
                var sendGridApiKey = _configuration["SendGridSettings:ApiKey"];
                var sendGridClient = new SendGridClient(sendGridApiKey);
                var fromEmail = _configuration["SendGridSettings:FromEmail"];
                var fromName = _configuration["SendGridSettings:FromName"];
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(fromEmail, fromName),
                    Subject = subject,
                    HtmlContent = body
                };
                msg.AddTo(new EmailAddress(toEmail));

                var response = await sendGridClient.SendEmailAsync(msg, cancellationToken);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendSmsAsync(string phoneNumber, string message, CancellationToken cancellationToken = default)
        {
            // Implement SMS sending logic using an SMS provider, such as Twilio.
            // Placeholder logic for SMS sending.
            return await Task.FromResult(true);
        }
    }
}
