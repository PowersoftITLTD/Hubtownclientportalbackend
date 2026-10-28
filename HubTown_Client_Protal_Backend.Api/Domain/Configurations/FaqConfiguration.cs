using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            // Correct table name mapping
            builder.ToTable("tbl_faq");

            // Configure the primary key
            builder.HasKey(f => f.FAQID);

            // Configure properties
            builder.Property(f => f.Question)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(f => f.Answer)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(f => f.CategoryID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.IsActive)
                   .IsRequired();

            builder.Property(f => f.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.CreatedDate)
                   .IsRequired();

            builder.Property(f => f.LastModifiedBy)
                   .HasMaxLength(100);

            builder.Property(f => f.LastModifiedDate)
                   .IsRequired();

            // Configure relationships
            builder.HasOne(d => d.Category)
               .WithMany() 
                .HasForeignKey(b => b.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
