using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_Notifications");

            // Configure primary key
            builder.HasKey(n => n.NotificationID);

            // Configure columns
            builder.Property(n => n.NotificationID)
                .HasColumnName("NotificationID");

            builder.Property(n => n.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(n => n.NotificationPayload)
                .HasColumnName("NotificationPayload")
                .HasColumnType("varchar(max)");

            builder.Property(n => n.NotificationType)
                .HasColumnName("NotificationType")
                .HasMaxLength(20);

            builder.Property(n => n.Status)
                .HasColumnName("Status")
                .HasMaxLength(20);

            builder.Property(n => n.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(n => n.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(n => n.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(n => n.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for Notification
                .HasForeignKey(n => n.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
