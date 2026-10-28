using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class ProjectImagesConfiguration : IEntityTypeConfiguration<ProjectImages>
    {
        public void Configure(EntityTypeBuilder<ProjectImages> entity)
        {
            entity.HasKey(e => e.ImageID); // Primary Key

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500) // Maximum length for ImageUrl
                .IsRequired(false); // Optional field

            entity.Property(e => e.IsActive)
                .IsRequired(); // Required field for IsActive

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100) // Maximum length for CreatedBy
                .IsRequired(false); // Optional field

            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(100) // Maximum length for LastModifiedBy
                .IsRequired(false); // Optional field

            entity.Property(e => e.CreatedDate)
                .IsRequired(); // Required field for CreatedDate

            entity.Property(e => e.LastModifiedDate)
                .IsRequired(false); // Optional field

            // Foreign Key relation to ProjectID
            entity.HasOne<Project>()
                .WithMany(p => p.ListProjectImages) // Assuming Project has ListProjectImages
                .HasForeignKey(e => e.ProjectID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Project is deleted
        }
    }

}
