using HubTown_Client_Protal_Backend.Api.Domain.Entity;

namespace HubTown_Client_Protal_Backend.Api.Application.Interfaces
{
    public interface INotificationService
    {
        Task<string> GetNotificationDetails(CancellationToken cancellationToken = default);
        Task<string> GetUpcomingProjectsDetails(CancellationToken cancellationToken = default);
        Task<List<Faq>> GetFAQ(CancellationToken cancellationToken = default);
        Task<IEnumerable<Notification>> GetNotificationsByBookingID(int BookingID, CancellationToken cancellationToken = default);
        Task<bool> UpdateNotificationStatus(int NotificationID, CancellationToken cancellationToken = default);
    }
}
