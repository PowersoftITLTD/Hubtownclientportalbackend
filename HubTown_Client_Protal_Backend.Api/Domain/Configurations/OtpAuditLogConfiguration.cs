using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class OtpAuditLogConfiguration : IEntityTypeConfiguration<OtpAuditLog>
    {
        public void Configure(EntityTypeBuilder<OtpAuditLog> builder)
        {
            // Configure the table name
            builder.ToTable("OtpAuditLog");

            // Configure primary key
            builder.HasKey(o => o.Id);

            // Configure columns
            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(o => o.UserID)
                .HasColumnName("UserID")
                .IsRequired(false);

            builder.Property(o => o.MobileNumber)
                .HasColumnName("MobileNumber")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(o => o.EmailID)
                .HasColumnName("EmailID")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(o => o.Channel)
                .HasColumnName("Channel")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(o => o.OTP)
                .HasColumnName("OTP")
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(o => o.OTPGeneratedAt)
                .HasColumnName("OTPGeneratedAt")
                .HasColumnType("datetime")
                .IsRequired(false);

            builder.Property(o => o.OTPExpiryAt)
                .HasColumnName("OTPExpiryAt")
                .HasColumnType("datetime")
                .IsRequired(false);

            builder.Property(o => o.OTPSendStatus)
                .HasColumnName("OTPSendStatus")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(o => o.SmsApiResponse)
                .HasColumnName("SmsApiResponse")
                .IsRequired(false);

            builder.Property(o => o.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            // Configure indexes
            builder.HasIndex(o => o.MobileNumber)
                .HasDatabaseName("IX_OtpAuditLog_MobileNumber");

            builder.HasIndex(o => o.UserID)
                .HasDatabaseName("IX_OtpAuditLog_UserID");

            builder.HasIndex(o => o.CreatedAt)
                .HasDatabaseName("IX_OtpAuditLog_CreatedAt");
        }
    }
}
