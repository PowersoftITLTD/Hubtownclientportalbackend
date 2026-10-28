namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class VerifyAdminRequest
    {
        public string? EmailID { get; set; }
        public string? MobileNumber { get; set; }
        public string? Password { get; set; }
    }
}
