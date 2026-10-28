namespace HubTown_Client_Protal_Backend.Api.Application.Interfaces
{
    public interface ISendService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string body, CancellationToken cancellationToken = default);
        Task<bool> SendSmsAsync(string phoneNumber, string message, CancellationToken cancellationToken = default);
    }
}
