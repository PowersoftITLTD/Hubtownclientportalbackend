using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_bankAccounts");

            // Configure primary key
            builder.HasKey(b => b.AccountID);

            // Configure columns
            builder.Property(b => b.AccountID)
                .HasColumnName("AccountID");

            builder.Property(b => b.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(b => b.Particulars)
                .HasColumnName("Particulars")
                .HasMaxLength(50);

            builder.Property(b => b.BankName)
                .HasColumnName("BankName")
                .HasMaxLength(50);

            builder.Property(b => b.BranchName)
                .HasColumnName("BranchName")
                .HasMaxLength(50);

            builder.Property(b => b.AccountNumber)
                .HasColumnName("AccountNumber")
                .HasMaxLength(20);

            builder.Property(b => b.IFSCCode)
                .HasColumnName("IFSCCode")
                .HasMaxLength(20);

            builder.Property(b => b.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(b => b.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(b => b.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(b => b.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(b => b.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
               .WithMany() // Assuming there is no collection property on Booking for BankAccount
                .HasForeignKey(b => b.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}