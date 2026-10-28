using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class User : CommonEntity
    {
        [Key]
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CurrentOTP { get; set; }
        public DateTime OTPExpiry { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
