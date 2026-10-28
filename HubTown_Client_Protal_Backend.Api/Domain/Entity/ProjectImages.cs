using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class ProjectImages
    {
        [Key]
        public int ImageID { get; set; }

        public int ProjectID { get; set; }

  
        public string? ImageUrl { get; set; }


        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }


        public DateTime CreatedDate { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

    }
}
