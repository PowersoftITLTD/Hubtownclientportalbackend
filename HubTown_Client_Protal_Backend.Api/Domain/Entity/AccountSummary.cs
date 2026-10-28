using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HubTown_Client_Protal_Backend.Api.Domain.Entity
{
    public class AccountSummary : CommonEntity
    {
        [Key]
        public int AccountSummaryID { get; set; }
        public int BookingID { get; set; }
        public decimal FC_DemandLetterRaised_Amount { get; set; }
        public decimal FC_DemandLetterRaised_Taxes { get; set; }
        public decimal SC_DemandLetterRaised_Amount { get; set; }
        public decimal SC_DemandLetterRaised_Taxes { get; set; }
        public decimal INT_DemandLetterRaised_Amount { get; set; }
        public decimal INT_DemandLetterRaised_Taxes { get; set; }
        public decimal Undjusted_DemandLetter { get; set; }
        public decimal FC_DiscountDemandLetter_Amount { get; set; }
        public decimal FC_DiscountDemandLetter_Taxes { get; set; }
        public decimal SC_DiscountDemandLetter_Amount { get; set; }
        public decimal SC_DiscountDemandLetter_Taxes { get; set; }
        public decimal INT_DiscountDemandLetter_Amount { get; set; }
        public decimal INT_DiscountDemandLetter_Taxes { get; set; }
        public decimal Undjusted_DiscountDemandLetter { get; set; }
        public decimal FC_Receipts_Amount { get; set; }
        public decimal FC_Receipts_Taxes { get; set; }
        public decimal SC_Receipts_Amount { get; set; }
        public decimal SC_Receipts_Taxes { get; set; }
        public decimal INT_Receipts_Amount { get; set; }
        public decimal INT_Receipts_Taxes { get; set; }
        public decimal Undjusted_Receipts { get; set; }
        public decimal FC_TransferAdjusted_Amount { get; set; }
        public decimal FC_TransferAdjusted_Taxes { get; set; }
        public decimal SC_TransferAdjusted_Amount { get; set; }
        public decimal SC_TransferAdjusted_Taxes { get; set; }
        public decimal INT_TransferAdjusted_Amount { get; set; }
        public decimal INT_TransferAdjusted_Taxes { get; set; }
        public decimal Undjusted_TransferAdjusted { get; set; }
        public decimal FC_TDS_Amount { get; set; }
        public decimal SC_TDS_Amount { get; set; }
        public decimal INT_TDS_Amount { get; set; }
        public decimal Undjusted_TDS { get; set; }
        public decimal FC_Payable_Amount { get; set; }
        public decimal FC_Payable_Taxes { get; set; }
        public decimal SC_Payable_Amount { get; set; }
        public decimal SC_Payable_Taxes { get; set; }
        public decimal INT_Payable_Amount { get; set; }
        public decimal INT_Payable_Taxes { get; set; }
        public decimal Undjusted_Payable { get; set; }

        // Navigation property for the relationship with Booking
        [JsonIgnore]
        public virtual Booking Booking { get; set; }
    }
}
