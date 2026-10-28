using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Booking : CommonEntity
    {
        [Key]
        public int BookingID { get; set; }
        public int? ProjectId { get; set; }
        public string? OCNo { get; set; }
        public DateTime? OCDate { get; set; }
        public string? Status { get; set; }
        public string? Building { get; set; }
        public string? Unit { get; set; }
        public string? Area { get; set; }
        public string? Floor { get; set; }
        public int? CarPark { get; set; }
        public string? UnitType { get; set; }
        public decimal? OutstandingWithinDueAmount { get; set; }
        public decimal? OutstandingOverdueAmount { get; set; }
        public decimal? TDSOutstanding { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime? RegistrationActualDate { get; set; }
        public DateTime? RegistrationTentativeDate { get; set; }
        public DateTime? FitoutDate { get; set; }
        public DateTime? PossessionFinalDate { get; set; }
        public string? RmName { get; set; }
        public string? RmEmail { get; set; }
        public string? RmContact { get; set; }
        public string? RegistrationDocumentUrl { set; get; }
        public string? PossessionDocumentUrl { set; get; }

        // Navigation property for the relationship with Project
        [JsonIgnore]
        public virtual Project Project { get; set; }

        [NotMapped]
        public virtual List<Project> ProjectList { get; set; }
    }
}
