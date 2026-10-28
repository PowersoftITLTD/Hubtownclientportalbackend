using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class HomeLoanNocConfiguration : IEntityTypeConfiguration<HomeLoanNoc>
    {
        public void Configure(EntityTypeBuilder<HomeLoanNoc> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_HomeLoanNoc");

            // Configure primary key
            builder.HasKey(h => h.NOCID);

            // Configure columns
            builder.Property(h => h.NOCID)
                .HasColumnName("NOCID");

            builder.Property(h => h.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(h => h.NocDate)
                .HasColumnName("NocDate")
                .HasColumnType("datetime");

            builder.Property(h => h.NocUrl)
                .HasColumnName("NocUrl")
                .HasColumnType("varchar(max)");

            builder.Property(h => h.Amount)
             .HasColumnName("Amount")
             .HasColumnType("money");

            builder.Property(h => h.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(h => h.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(h => h.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(h => h.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(h => h.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for HomeLoanNoc
                .HasForeignKey(h => h.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
