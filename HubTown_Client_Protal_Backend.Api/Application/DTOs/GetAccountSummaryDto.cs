namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class GetAccountSummaryDto 
    {
        
        public DemandLetterAmountRaised DemandLetterAmountRaised { get; set; }
        public DiscountOnDemandLetter DiscountOnDemandLetter { get; set; }
        public Receipts Receipts { get; set; }
        public TransferAdjusted TransferAdjusted { get; set; }
        public TDSAmountReceived TDSAmountReceived { get; set; }
        public AmountPayable AmountPayable { get; set; }

    }

    public class DemandLetterAmountRaised
    {
        public decimal FC_DemandLetterRaised_Amount { get; set; }
        public decimal FC_DemandLetterRaised_Taxes { get; set; }
        public decimal SC_DemandLetterRaised_Amount { get; set; }
        public decimal SC_DemandLetterRaised_Taxes { get; set; }
        public decimal INT_DemandLetterRaised_Amount { get; set; }
        public decimal INT_DemandLetterRaised_Taxes { get; set; }
        public decimal Undjusted_DemandLetter { get; set; }
    }

    public class DiscountOnDemandLetter
    {
        public decimal FC_DiscountDemandLetter_Amount { get; set; }
        public decimal FC_DiscountDemandLetter_Taxes { get; set; }
        public decimal SC_DiscountDemandLetter_Amount { get; set; }
        public decimal SC_DiscountDemandLetter_Taxes { get; set; }
        public decimal INT_DiscountDemandLetter_Amount { get; set; }
        public decimal INT_DiscountDemandLetter_Taxes { get; set; }
        public decimal Undjusted_DiscountDemandLetter { get; set; }
    }

    public class Receipts
    {
        public decimal FC_Receipts_Amount { get; set; }
        public decimal FC_Receipts_Taxes { get; set; }
        public decimal SC_Receipts_Amount { get; set; }
        public decimal SC_Receipts_Taxes { get; set; }
        public decimal INT_Receipts_Amount { get; set; }
        public decimal INT_Receipts_Taxes { get; set; }
        public decimal Undjusted_Receipts { get; set; }
    }

    public class TransferAdjusted
    {
        public decimal FC_TransferAdjusted_Amount { get; set; }
        public decimal FC_TransferAdjusted_Taxes { get; set; }
        public decimal SC_TransferAdjusted_Amount { get; set; }
        public decimal SC_TransferAdjusted_Taxes { get; set; }
        public decimal INT_TransferAdjusted_Amount { get; set; }
        public decimal INT_TransferAdjusted_Taxes { get; set; }
        public decimal Undjusted_TransferAdjusted { get; set; }
    }

    public class TDSAmountReceived
    {
        public decimal FC_TDS_Amount { get; set; }
        public decimal SC_TDS_Amount { get; set; }
        public decimal INT_TDS_Amount { get; set; }
        public decimal Undjusted_TDS { get; set; }
    }

    public class AmountPayable
    {
        public decimal FC_Payable_Amount { get; set; }
        public decimal FC_Payable_Taxes { get; set; }
        public decimal SC_Payable_Amount { get; set; }
        public decimal SC_Payable_Taxes { get; set; }
        public decimal INT_Payable_Amount { get; set; }
        public decimal INT_Payable_Taxes { get; set; }
        public decimal Undjusted_Payable { get; set; }
    }
}
