using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class UnitOwnerConfiguration : IEntityTypeConfiguration<UnitOwner>
    {
        public void Configure(EntityTypeBuilder<UnitOwner> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_unitOwners");

            // Configure primary key
            builder.HasKey(uo => uo.UnitOwnerID);

            // Configure columns
            builder.Property(uo => uo.UnitOwnerID)
                .HasColumnName("UnitOwnerID");

            builder.Property(uo => uo.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(uo => uo.UserID)
                .HasColumnName("UserID")
                .IsRequired();

            builder.Property(uo => uo.OwnershipType)
                .HasColumnName("OwnershipType")
                .HasMaxLength(20);

            builder.Property(uo => uo.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(uo => uo.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for UnitOwner
                .HasForeignKey(uo => uo.BookingID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.User)
                .WithMany() // Assuming there is no collection property on User for UnitOwner
                .HasForeignKey(uo => uo.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}