using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Receipt : CommonEntity
    {
        [Key]
        public int ReceiptID { get; set; }
        public int BookingID { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string ReceiptNo { get; set; }
        public decimal ReceiptAmt { get; set; }
        public string ReceiptUrl { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking Booking { get; set; }
    }
}
