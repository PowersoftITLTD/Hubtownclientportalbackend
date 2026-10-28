using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_users");

            // Configure primary key
            builder.HasKey(u => u.UserID);

            // Configure columns
            builder.Property(u => u.UserID)
                .HasColumnName("UserID")
                .HasDefaultValueSql("NEWID()"); // Default value for UNIQUEIDENTIFIER

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Mobile)
                .HasColumnName("Mobile")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(u => u.CurrentOTP)
                .HasColumnName("CurrentOTP")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(u => u.OTPExpiry)
                .HasColumnName("OTPExpiry")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(u => u.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(u => u.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()"); // Default value for CreatedAt

            builder.Property(u => u.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(u => u.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            builder.Property(u => u.Password)
               .HasColumnName("Password")
               .HasMaxLength(50)
               .IsRequired(false);

            builder.Property(u => u.IsAdmin)
              .HasColumnName("IsAdmin");
        }
    }
}
