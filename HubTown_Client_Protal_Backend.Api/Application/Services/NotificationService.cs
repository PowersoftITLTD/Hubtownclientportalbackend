using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories;

namespace HubTown_Client_Protal_Backend.Api.Application.Services
{
    public class NotificationService(INotificationRepository _NotificationRepository) : INotificationService
    {
        public Task<string> GetNotificationDetails(CancellationToken cancellationToken = default)
        {
            return _NotificationRepository.GetNotificationDetails(cancellationToken);
        }

        public Task<string> GetUpcomingProjectsDetails(CancellationToken cancellationToken = default)
        {
            return _NotificationRepository.GetUpcomingProjectsDetails(cancellationToken);
        }

        public Task<List<Faq>> GetFAQ(CancellationToken cancellationToken = default)
        {
            return _NotificationRepository.GetFAQ(cancellationToken);
        }
        public Task<IEnumerable<Notification>> GetNotificationsByBookingID(int BookingID, CancellationToken cancellationToken = default)
        {
            return _NotificationRepository.GetNotificationsByBookingID(BookingID, cancellationToken);
        }
        public Task<bool> UpdateNotificationStatus(int NotificationID, CancellationToken cancellationToken = default)
        {
            return _NotificationRepository.UpdateNotificationStatus(NotificationID, cancellationToken);
        }

    }
}
