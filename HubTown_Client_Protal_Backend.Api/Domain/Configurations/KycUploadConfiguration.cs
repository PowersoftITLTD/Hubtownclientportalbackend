using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class KycUploadConfiguration : IEntityTypeConfiguration<KycUpload>
    {
        public void Configure(EntityTypeBuilder<KycUpload> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_kycUpload");

            // Configure primary key
            builder.HasKey(k => k.KycId);

            // Configure columns
            builder.Property(k => k.KycId)
                .HasColumnName("KycId")
                .HasDefaultValueSql("NEWID()");

            builder.Property(k => k.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(k => k.OwnerName)
                .HasColumnName("OwnerName")
                .HasMaxLength(50);

            builder.Property(k => k.DocumentName)
                .HasColumnName("DocumentName")
                .HasMaxLength(30);

            builder.Property(k => k.DocumentFile)
                .HasColumnName("DocumentFile")
                .HasColumnType("varchar(max)");

            builder.Property(k => k.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(k => k.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(k => k.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(k => k.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            builder.Property(k => k.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for KycUpload
                .HasForeignKey(k => k.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
