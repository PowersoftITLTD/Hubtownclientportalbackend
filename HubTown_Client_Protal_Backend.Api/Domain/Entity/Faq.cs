namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class Faq
    {
        public int FAQID { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }

        // Foreign key reference to CategoryMaster
        public int CategoryID { get; set; }

        // Navigation property to the CategoryMaster
        public virtual CategoryMaster? Category { get; set; }

        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
