using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class ProjectUpdateImagesConfiguration : IEntityTypeConfiguration<ProjectUpdateImages>
    {
        public void Configure(EntityTypeBuilder<ProjectUpdateImages> entity)
        {
            entity.HasKey(e => e.UpdateImageID); // Primary Key

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500) // Assuming maximum length for ImageUrl is 500
                .IsRequired(false); // Optional field

            entity.Property(e => e.IsActive)
                .IsRequired(false); // Optional field

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100) // Maximum length for CreatedBy
                .IsRequired(false); // Optional field

            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(100) // Maximum length for LastModifiedBy
                .IsRequired(false); // Optional field

            entity.Property(e => e.CreatedDate)
                .IsRequired(false); // Optional field

            entity.Property(e => e.LastModifiedDate)
                .IsRequired(false); // Optional field

            // Foreign Key relation to UpdateID
            entity.HasOne<ProjectUpdate>() // Assuming there's a ProjectUpdate entity
                .WithMany(p => p.ProjectUpdateImages) // Assuming ProjectUpdate has a collection of ProjectUpdateImages
                .HasForeignKey(e => e.UpdateID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when the related update is deleted
        }
    }

}
