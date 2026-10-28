using System.ComponentModel.DataAnnotations;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class OtpAuditLog
    {
        public long Id { get; set; }
        public Guid? UserID { get; set; }
        public string MobileNumber { get; set; }
        public string? EmailID { get; set; }
        public string? Channel { get; set; } // "SMS" or "EMAIL"
        public string OTP { get; set; }
        public DateTime? OTPGeneratedAt { get; set; }
        public DateTime? OTPExpiryAt { get; set; }
        public bool OTPSendStatus { get; set; }
        public string SmsApiResponse { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
