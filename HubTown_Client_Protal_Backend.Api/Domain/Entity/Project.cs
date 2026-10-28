using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Project : CommonEntity
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? Status { get; set; }
        public string? ProjectLogoUrl { get; set; }
        public string? Rerano { get; set; }
        public string? ReraDocument { get; set; }
        public string? ReraLink { get; set; }
        public string? Address { get; set; }
        public string? Facebooklink { get; set; }
        public string? Instagramlink { get; set; }
        public string? ProjectImage { get; set; }
        public bool IsUcomming { get; set; }
        public string? websiteLink { get; set; }
        [JsonPropertyOrder(100)]
        public virtual Booking? booking { get; set; }

        [ForeignKey("ProjectID")]
        public virtual List<ProjectImages>? ListProjectImages { get; set; }

    }
}
