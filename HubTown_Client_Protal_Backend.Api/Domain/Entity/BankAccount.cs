using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class BankAccount : CommonEntity
    {
        [Key]
        public int AccountID { get; set; }
        public int BookingID { get; set; }
        public string Particulars { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking Booking { get; set; }
    }
}
