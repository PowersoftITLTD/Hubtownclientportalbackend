namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class UploadTDSFileRequest
    {
        //public int TDSId { get; set; }
        public IFormFile File { get; set; }
        public int BookingID { get; set; }
        public DateTime TDSDate { get; set; }
        public string TransactionNo { get; set; }
        public decimal TDSAmount { get; set; }
        public Guid UserID { get; set; }
        //public string CreatedBy { get; set; }
    }
}
