using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    [Table("CategoryMaster")]
    public class CategoryMaster
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Navigation property for related FAQs
        
    }
}
