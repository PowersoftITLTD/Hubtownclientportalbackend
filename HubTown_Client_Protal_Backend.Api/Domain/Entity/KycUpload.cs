using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class KycUpload : CommonEntity
    {
        [Key]
        public Guid KycId { get; set; }
        public int BookingID { get; set; }
        public string? OwnerName { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentFile { get; set; }


        // Navigation property for the relationship with Booking
        public virtual Booking? Booking { get; set; }
    }
}
