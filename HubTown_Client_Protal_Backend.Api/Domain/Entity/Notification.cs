using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Notification : CommonEntity
    {
        [Key]
        public int NotificationID { get; set; }
        public int BookingID { get; set; }
        public string NotificationPayload { get; set; }
        public string NotificationType { get; set; }
        public Boolean Status { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking Booking { get; set; }
    }
}
