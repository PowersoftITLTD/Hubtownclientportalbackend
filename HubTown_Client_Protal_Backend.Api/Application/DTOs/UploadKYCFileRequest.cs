namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class UploadKYCFileRequest
    {
        //public Guid KycId { get; set; }
        public IFormFile File { get; set; }
        public int BookingID { get; set; }
        public string OwnerName { get; set; }

        public string DocumentName { get; set; }
        public Guid UserID { get; set; }
        //public string CreatedBy { get; set; }
    }
}
