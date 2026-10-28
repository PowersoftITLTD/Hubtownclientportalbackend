using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class UserLogin : CommonEntity
    {
        [Key]
        public Guid LoginID { get; set; }
        public Guid UserID { get; set; }
        public string OTP { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UsedAt { get; set; }

        //Added property UserName
        public string? UserName { get; set; }

        // Navigation property for the relationship with User
        //public virtual User? User { get; set; }
    }
}
