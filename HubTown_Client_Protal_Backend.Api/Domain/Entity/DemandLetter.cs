using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class DemandLetter : CommonEntity
    {
        [Key]
        public int InvoiceID { get; set; }
        public int BookingID { get; set; }
        public string? InvoiceDescription { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? InvoiceNo { get; set; }
        public decimal? InvoiceAmt { get; set; }
        public string? InvoiceUrl { get; set; }

        // Navigation property for the relationship with Booking
        public virtual Booking? Booking { get; set; }

        // Added By Itemad Hyder 27-10-2026
        public string? url { get; set; }
    }
}
