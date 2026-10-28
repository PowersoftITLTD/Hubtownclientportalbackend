using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class DemandLetterConfiguration : IEntityTypeConfiguration<DemandLetter>
    {
        public void Configure(EntityTypeBuilder<DemandLetter> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_DemandLetter");

            // Configure primary key
            builder.HasKey(d => d.InvoiceID);

            // Configure columns
            builder.Property(d => d.InvoiceID)
                .HasColumnName("InvoiceID");

            builder.Property(d => d.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(d => d.InvoiceDescription)
                .HasColumnName("InvoiceDescription")
                .HasColumnType("varchar(30)");

            builder.Property(d => d.InvoiceDate)
                .HasColumnName("InvoiceDate")
                .HasColumnType("datetime");

            builder.Property(d => d.InvoiceNo)
                .HasColumnName("InvoiceNo")
                .HasMaxLength(20);

            builder.Property(d => d.InvoiceAmt)
                .HasColumnName("InvoiceAmt")
                .HasColumnType("money");

            builder.Property(d => d.InvoiceUrl)
                .HasColumnName("InvoiceUrl")
                .HasColumnType("varchar(max)");

            builder.Property(d => d.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(d => d.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(d => d.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(d => d.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(d => d.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for DemandLetter
                .HasForeignKey(d => d.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
