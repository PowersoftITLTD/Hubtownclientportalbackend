using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Image : CommonEntity
    {
        [Key]
        public int ImageId { get; set; }
        public int ProjectId { get; set; }
        public string ImageUrl { get; set; }

        // Navigation property for the relationship with Project
        public virtual Project Project { get; set; }
    }
}
