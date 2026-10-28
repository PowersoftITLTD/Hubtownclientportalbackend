namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class FeedbackRequest
    {
        public string BuildingName { get; set; }
        public string UnitNo { get; set; }
        public int InfId { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
        public string? Source { get; set; }

    }
}
