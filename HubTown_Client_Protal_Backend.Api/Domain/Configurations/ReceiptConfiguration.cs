using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_Receipts");

            // Configure primary key
            builder.HasKey(r => r.ReceiptID);

            // Configure columns
            builder.Property(r => r.ReceiptID)
                .HasColumnName("ReceiptID");

            builder.Property(r => r.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(r => r.ReceiptDate)
                .HasColumnName("ReceiptDate")
                .HasColumnType("datetime");

            builder.Property(r => r.ReceiptNo)
                .HasColumnName("ReceiptNo")
                .HasMaxLength(20);

            builder.Property(r => r.ReceiptAmt)
                .HasColumnName("ReceiptAmt")
                .HasColumnType("money");

            builder.Property(r => r.ReceiptUrl)
                .HasColumnName("ReceiptUrl")
                .HasColumnType("varchar(max)");

            builder.Property(r => r.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(r => r.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(r => r.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(r => r.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(r => r.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for Receipt
                .HasForeignKey(r => r.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
