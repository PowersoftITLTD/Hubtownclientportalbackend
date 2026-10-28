using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class AccountSummaryConfiguration : IEntityTypeConfiguration<AccountSummary>
    {
        public void Configure(EntityTypeBuilder<AccountSummary> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_AccountSummary");

            // Configure primary key
            builder.HasKey(a => a.AccountSummaryID);

            // Configure columns
            builder.Property(a => a.AccountSummaryID)
                .HasColumnName("AccountSummaryID");

            builder.Property(a => a.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(a => a.FC_DemandLetterRaised_Amount)
                .HasColumnName("FC_DemandLetterRaised_Amount")
                .HasColumnType("money");

            builder.Property(a => a.FC_DemandLetterRaised_Taxes)
                .HasColumnName("FC_DemandLetterRaised_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.SC_DemandLetterRaised_Amount)
                .HasColumnName("SC_DemandLetterRaised_Amount")
                .HasColumnType("money");

            builder.Property(a => a.SC_DemandLetterRaised_Taxes)
                .HasColumnName("SC_DemandLetterRaised_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.INT_DemandLetterRaised_Amount)
                .HasColumnName("INT_DemandLetterRaised_Amount")
                .HasColumnType("money");

            builder.Property(a => a.INT_DemandLetterRaised_Taxes)
                .HasColumnName("INT_DemandLetterRaised_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.Undjusted_DemandLetter)
                .HasColumnName("Undjusted_DemandLetter")
                .HasColumnType("money");

            builder.Property(a => a.FC_DiscountDemandLetter_Amount)
                .HasColumnName("FC_DiscountDemandLetter_Amount")
                .HasColumnType("money");

            builder.Property(a => a.FC_DiscountDemandLetter_Taxes)
                .HasColumnName("FC_DiscountDemandLetter_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.SC_DiscountDemandLetter_Amount)
                .HasColumnName("SC_DiscountDemandLetter_Amount")
                .HasColumnType("money");

            builder.Property(a => a.SC_DiscountDemandLetter_Taxes)
                .HasColumnName("SC_DiscountDemandLetter_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.INT_DiscountDemandLetter_Amount)
                .HasColumnName("INT_DiscountDemandLetter_Amount")
                .HasColumnType("money");

            builder.Property(a => a.INT_DiscountDemandLetter_Taxes)
                .HasColumnName("INT_DiscountDemandLetter_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.Undjusted_DiscountDemandLetter)
                .HasColumnName("Undjusted_DiscountDemandLetter")
                .HasColumnType("money");

            builder.Property(a => a.FC_Receipts_Amount)
                .HasColumnName("FC_Receipts_Amount")
                .HasColumnType("money");

            builder.Property(a => a.FC_Receipts_Taxes)
                .HasColumnName("FC_Receipts_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.SC_Receipts_Amount)
                .HasColumnName("SC_Receipts_Amount")
                .HasColumnType("money");

            builder.Property(a => a.SC_Receipts_Taxes)
                .HasColumnName("SC_Receipts_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.INT_Receipts_Amount)
                .HasColumnName("INT_Receipts_Amount")
                .HasColumnType("money");

            builder.Property(a => a.INT_Receipts_Taxes)
                .HasColumnName("INT_Receipts_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.Undjusted_Receipts)
                .HasColumnName("Undjusted_Receipts")
                .HasColumnType("money");

            builder.Property(a => a.FC_TransferAdjusted_Amount)
                .HasColumnName("FC_TransferAdjusted_Amount")
                .HasColumnType("money");

            builder.Property(a => a.FC_TransferAdjusted_Taxes)
                .HasColumnName("FC_TransferAdjusted_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.SC_TransferAdjusted_Amount)
                .HasColumnName("SC_TransferAdjusted_Amount")
                .HasColumnType("money");

            builder.Property(a => a.SC_TransferAdjusted_Taxes)
                .HasColumnName("SC_TransferAdjusted_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.INT_TransferAdjusted_Amount)
                .HasColumnName("INT_TransferAdjusted_Amount")
                .HasColumnType("money");

            builder.Property(a => a.INT_TransferAdjusted_Taxes)
                .HasColumnName("INT_TransferAdjusted_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.Undjusted_TransferAdjusted)
                .HasColumnName("Undjusted_TransferAdjusted")
                .HasColumnType("money");

            builder.Property(a => a.FC_TDS_Amount)
                .HasColumnName("FC_TDS_Amount")
                .HasColumnType("money");

            builder.Property(a => a.SC_TDS_Amount)
                .HasColumnName("SC_TDS_Amount")
                .HasColumnType("money");

            builder.Property(a => a.INT_TDS_Amount)
                .HasColumnName("INT_TDS_Amount")
                .HasColumnType("money");

            builder.Property(a => a.Undjusted_TDS)
                .HasColumnName("Undjusted_TDS")
                .HasColumnType("money");

            builder.Property(a => a.FC_Payable_Amount)
                .HasColumnName("FC_Payable_Amount")
                .HasColumnType("money");

            builder.Property(a => a.FC_Payable_Taxes)
                .HasColumnName("FC_Payable_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.SC_Payable_Amount)
                .HasColumnName("SC_Payable_Amount")
                .HasColumnType("money");

            builder.Property(a => a.SC_Payable_Taxes)
                .HasColumnName("SC_Payable_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.INT_Payable_Amount)
                .HasColumnName("INT_Payable_Amount")
                .HasColumnType("money");

            builder.Property(a => a.INT_Payable_Taxes)
                .HasColumnName("INT_Payable_Taxes")
                .HasColumnType("money");

            builder.Property(a => a.Undjusted_Payable)
                .HasColumnName("Undjusted_Payable")
                .HasColumnType("money");

            builder.Property(a => a.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(a => a.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(a => a.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(a => a.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                   .WithMany() // Assuming there is no collection property on Booking for Account summary
                   .HasForeignKey(d => d.BookingID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
