using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_booking");

            // Configure primary key
            builder.HasKey(b => b.BookingID);

            // Configure columns
            builder.Property(b => b.BookingID)
                .HasColumnName("BookingID");

            builder.Property(b => b.ProjectId)
                .HasColumnName("ProjectId")
                .IsRequired();

            builder.Property(b => b.OCNo)
                .HasColumnName("OCNo")
                .HasMaxLength(20);

            builder.Property(b => b.OCDate)
                .HasColumnName("OCDate")
                .HasColumnType("datetime");

            builder.Property(b => b.Status)
                .HasColumnName("Status")
                .HasMaxLength(30);

            builder.Property(b => b.Building)
                .HasColumnName("Building")
                .HasMaxLength(20);

            builder.Property(b => b.Unit)
                .HasColumnName("Unit")
                .HasMaxLength(20);

            builder.Property(b => b.Area)
                .HasColumnName("Area")
                .HasMaxLength(20);

            builder.Property(b => b.Floor)
                .HasColumnName("Floor")
                .HasMaxLength(20);

            builder.Property(b => b.CarPark)
                .HasColumnName("CarPark");

            builder.Property(b => b.UnitType)
                .HasColumnName("UnitType")
                .HasMaxLength(20);

            builder.Property(b => b.OutstandingWithinDueAmount)
                .HasColumnName("OutstandingWithinDueAmount")
                .HasColumnType("money");

            builder.Property(b => b.OutstandingOverdueAmount)
                .HasColumnName("OutstandingOverdueAmount")
                .HasColumnType("money");

            builder.Property(b => b.TDSOutstanding)
                .HasColumnName("TDSOutstanding")
                .HasColumnType("money");

            builder.Property(b => b.RegistrationNumber)
                .HasColumnName("RegistrationNumber")
                .HasMaxLength(30);

            builder.Property(b => b.RegistrationActualDate)
                .HasColumnName("RegistrationActualDate")
                .HasColumnType("datetime");

            builder.Property(b => b.RegistrationTentativeDate)
                .HasColumnName("RegistrationTentativeDate")
                .HasColumnType("datetime");

            builder.Property(b => b.FitoutDate)
                .HasColumnName("FitoutDate")
                .HasColumnType("datetime");

            builder.Property(b => b.RegistrationDocumentUrl)
           .HasColumnName("RegistrationDocumentUrl")
           .HasColumnType("varchar(max)");

            builder.Property(b => b.PossessionDocumentUrl)
           .HasColumnName("PossessionDocumentUrl")
           .HasColumnType("varchar(max)");

            builder.Property(b => b.PossessionFinalDate)
                .HasColumnName("PossessionFinalDate")
                .HasColumnType("datetime");

            builder.Property(b => b.RmName)
                .HasColumnName("RmName")
                .HasMaxLength(50);

            builder.Property(b => b.RmEmail)
                .HasColumnName("RmEmail")
                .HasMaxLength(50);

            builder.Property(b => b.RmContact)
                .HasColumnName("RmContact")
                .HasMaxLength(15);

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
            builder.HasOne(d => d.Project)
               .WithMany() // Assuming there is no collection property on Project for Booking
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
