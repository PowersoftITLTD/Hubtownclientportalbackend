using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Tds : CommonEntity
    {
        [Key]
        public Guid TDSId { get; set; }
        public int BookingID { get; set; }
        public DateTime TDSDate { get; set; }
        public string TransactionNo { get; set; }
        public decimal TDSAmount { get; set; }
        public string TDSFile { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking? Booking { get; set; }
    }
}
