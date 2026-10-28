using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class UnitOwner : CommonEntity
    {
        [Key]
        public int UnitOwnerID { get; set; }
        public int BookingID { get; set; }
        public Guid UserID { get; set; }
        public string OwnershipType { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking Booking { get; set; }

        // Navigation property for the relationship with User
        public virtual User User { get; set; }
    }
}
