using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_UserLogin");

            // Configure primary key
            builder.HasKey(ul => ul.LoginID);

            // Configure columns
            builder.Property(ul => ul.LoginID)
                .HasColumnName("LoginID")
                .HasDefaultValueSql("NEWID()"); // Assuming you use GUID as the default value

            builder.Property(ul => ul.UserID)
                .HasColumnName("UserID")
                .IsRequired();

            builder.Property(ul => ul.OTP)
                .HasColumnName("OTP")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(ul => ul.ExpiresAt)
                .HasColumnName("ExpiresAt")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(ul => ul.IsUsed)
                .HasColumnName("IsUsed")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(ul => ul.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(ul => ul.UsedAt)
                .HasColumnName("UsedAt")
                .HasColumnType("datetime");

            builder.Property(ul => ul.UserName)
                .HasColumnName("UserName");
                

            // Configure relationships
            //builder.HasOne(d => d.User)
            //    .WithMany() // Assuming there is no collection property on User for UserLogin
            //    .HasForeignKey(ul => ul.UserID)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
