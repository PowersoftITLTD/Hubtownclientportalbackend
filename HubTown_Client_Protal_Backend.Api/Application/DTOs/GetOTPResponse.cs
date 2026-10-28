namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class GetOTPResponse
    {
        public Guid UserID { get; set; } = Guid.Empty;
        public bool OTPSend { get; set; } = false;
        public string? Message { get; set; }
    }
}
