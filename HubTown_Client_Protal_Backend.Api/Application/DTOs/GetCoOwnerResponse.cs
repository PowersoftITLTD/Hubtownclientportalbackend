using System.Security.Principal;

namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class GetCoOwnerResponse
    {
        public int BookingID { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string? ownerShipType { get; set; }
    }
}
