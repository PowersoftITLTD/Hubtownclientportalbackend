namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class VerifyOTPRequest
    {
        public Guid UserID { get; set; }
        public string? EnteredOTP { get; set; }

        public  bool IsAdmin {get; set;}
    }
}
