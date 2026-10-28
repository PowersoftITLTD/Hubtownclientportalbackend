using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class ProjectUpdateImages
    {
        [Key] // Marks this property as the primary key
        public int UpdateImageID { get; set; } // Primary key, non-nullable

        public int? UpdateID { get; set; }     // Nullable int
        public string? ImageUrl { get; set; }   // Nullable string
        public bool? IsActive { get; set; }     // Nullable bool
        public string? CreatedBy { get; set; }  // Nullable string
        public DateTime? CreatedDate { get; set; } // Nullable DateTime
        public string? LastModifiedBy { get; set; } // Nullable string
        public DateTime? LastModifiedDate { get; set; } // Nullable DateTime

        //public virtual ProjectUpdate? ProjectUpdate { get; set; }
    }
}
