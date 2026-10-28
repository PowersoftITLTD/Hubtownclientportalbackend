using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Feedback
    {
        [Key]
        public long FeedbackID { get; set; }
        public string BuildingName { get; set; }
        public string UnitNo { get; set; }
        public int InfId { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Source { get; set; }

        [JsonIgnore]
        public virtual Information? Information { get; set; }
    }
}
