using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class HomeLoanNoc : CommonEntity
    {
        [Key]
        public string NOCID { get; set; }
        public int BookingID { get; set; }
        public DateTime? NocDate { get; set; }
        public string? NocUrl { get; set; }

        public decimal? Amount { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking? Booking { get; set; }
    }
}
