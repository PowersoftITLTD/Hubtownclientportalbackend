using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class ProjectUpdate
    {
        [Key]
        public int UpdateID { get; set; }

        public int ProjectID { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }


        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string? ProjectImage { get; set; }

        [ForeignKey("UpdateID")]
        public virtual List<ProjectUpdateImages>? ProjectUpdateImages { get; set; }

        public virtual Project? Project { get; set; }
    }
}
