using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class CategoryMasterConfiguration : IEntityTypeConfiguration<CategoryMaster>
    {
        public void Configure(EntityTypeBuilder<CategoryMaster> builder)
        {
            // Map to specific table name
            builder.ToTable("CategoryMaster");

            // Set primary key
            builder.HasKey(c => c.CategoryID);

            // Configure columns
            builder.Property(c => c.CategoryName)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            // Configure timestamps
            builder.Property(c => c.CreatedDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.ModifiedDate)
                   .HasDefaultValueSql("GETDATE()")
                   .ValueGeneratedOnAddOrUpdate();

            builder.Property(c => c.CreatedBy)
                   .HasMaxLength(255); // Optional: Adjust as necessary

            builder.Property(c => c.ModifiedBy)
                   .HasMaxLength(255); // Optional: Adjust as necessary
        }
    }
}
