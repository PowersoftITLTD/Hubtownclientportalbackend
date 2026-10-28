using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class DemandBreakup : CommonEntity
    {
        [Key]
        public int BreakupID { get; set; }
        public int BookingID { get; set; }
        public decimal? FlatConsiderationAmt { get; set; }
        public decimal? SocietyCharges { get; set; }
        public string? Society { get; set; }
        public decimal? StatutoryRequirements { get; set; }
        public decimal? TotalWoTax { get; set; }

        public string? GroupA_Caption {  get; set; }
        public string? GroupB_Caption { get; set; }
        public string? GroupC_Caption { get; set; }
        public string? GroupD_Caption { get; set; }


        // Navigation property for the relationship with Booking
        [JsonIgnore]
        public virtual Booking? Booking { get; set; }
    }
}
