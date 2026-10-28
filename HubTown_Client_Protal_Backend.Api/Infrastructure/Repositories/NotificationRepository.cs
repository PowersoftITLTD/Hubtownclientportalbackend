using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _dbContext;

        public NotificationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetNotificationDetails(CancellationToken cancellationToken = default)
        {
            try
            {
                return "";
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public async Task<string> GetUpcomingProjectsDetails(CancellationToken cancellationToken = default)
        {
            try
            {
                return "";
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public async Task<List<Faq>> GetFAQ(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Faqs.Include(f => f.Category)
                                   .Where(f => f.IsActive) // Only return active FAQs
                                   .ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Notification>> GetNotificationsByBookingID(int BookingID, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.notifications
                    .Where(n => n.BookingID == BookingID && n.IsActive && n.Status) // Assuming IsActive is a boolean property
                    .ToListAsync(cancellationToken);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateNotificationStatus(int NotificationID, CancellationToken cancellationToken = default)
        {
            try
            {
                var notification = await _dbContext.notifications
                    .FirstOrDefaultAsync(n => n.NotificationID == NotificationID, cancellationToken);

                if (notification != null)
                {
                    notification.Status = false;  // Set status to false (or true based on your logic)
                    _dbContext.notifications.Update(notification);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
    }
}
