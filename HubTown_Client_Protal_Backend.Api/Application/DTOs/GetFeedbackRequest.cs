namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class GetFeedbackRequest
    {
        public string? BuildingName { get; set; }
        public string? UnitNo { get; set; }
        public string? CustomerName { get; set; }
        public string? Source { get; set; }
    }
}
