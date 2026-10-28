using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class TdsConfiguration : IEntityTypeConfiguration<Tds>
    {
        public void Configure(EntityTypeBuilder<Tds> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_Tds");

            // Configure primary key
            builder.HasKey(t => t.TDSId);

            // Configure columns
            builder.Property(t => t.TDSId)
                .HasColumnName("TDSId")
                .HasDefaultValueSql("NEWID()");

            builder.Property(t => t.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(t => t.TDSDate)
                .HasColumnName("TDSDate")
                .HasColumnType("datetime");

            builder.Property(t => t.TransactionNo)
                .HasColumnName("TransactionNo")
                .HasMaxLength(20);

            builder.Property(t => t.TDSAmount)
                .HasColumnName("TDSAmount")
                .HasColumnType("money");

            builder.Property(t => t.TDSFile)
                .HasColumnName("TDSFile")
                .HasColumnType("varchar(max)");

            builder.Property(t => t.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(t => t.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(t => t.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for Tds
                .HasForeignKey(t => t.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
