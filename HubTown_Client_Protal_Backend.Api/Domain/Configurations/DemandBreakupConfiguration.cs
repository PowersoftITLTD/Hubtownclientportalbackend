using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class DemandBreakupConfiguration : IEntityTypeConfiguration<DemandBreakup>
    {
        public void Configure(EntityTypeBuilder<DemandBreakup> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_demandBreakup");

            // Configure primary key
            builder.HasKey(d => d.BreakupID);

            // Configure columns
            builder.Property(d => d.BreakupID)
                .HasColumnName("BreakupID");

            builder.Property(d => d.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(d => d.FlatConsiderationAmt)
                .HasColumnName("FlatConsiderationAmt")
                .HasColumnType("money");

            builder.Property(d => d.SocietyCharges)
                .HasColumnName("SocietyCharges")
                .HasColumnType("money");

            builder.Property(d => d.Society)
                .HasColumnName("Society")
                .HasMaxLength(50);

            builder.Property(d => d.StatutoryRequirements)
                .HasColumnName("StatutoryRequirements")
                .HasColumnType("money");

            builder.Property(d => d.TotalWoTax)
                .HasColumnName("TotalWoTax")
                .HasColumnType("money");

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
                   .WithMany() // Assuming there is no collection property on Booking for DemandBreakup
                   .HasForeignKey(d => d.BookingID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
