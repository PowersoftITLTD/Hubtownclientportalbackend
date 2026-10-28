namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class CommonEntity
    {
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
