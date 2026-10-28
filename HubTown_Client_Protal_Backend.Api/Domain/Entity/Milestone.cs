using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Milestone : CommonEntity
    {
        [Key]
        public int MilestoneId { get; set; }
        public int BookingID { get; set; }
        public string? MileStoneName { get; set; }
        public decimal? Amount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? TentativeDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string? CurrentMS { get; set; }
        public string? MilestoneDocUrl { get; set; }

        public int? Sequenceno { get; set; }

        public decimal? Totalamount { get; set; }

        public decimal? Mile_Perc { get; set; }

        public decimal? Pendingamount { get; set; }
        public decimal? Paidamount { get; set; }

        public decimal? Invoice { get; set; }

        public decimal? Reciept { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking? Booking { get; set; }

        [NotMapped]
        public virtual decimal? flatConsiderationamount { get; set; }



    }
}
