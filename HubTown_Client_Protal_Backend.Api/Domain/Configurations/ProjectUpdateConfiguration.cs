using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class ProjectUpdateConfiguration : IEntityTypeConfiguration<ProjectUpdate>
    {
        public void Configure(EntityTypeBuilder<ProjectUpdate> builder)
        {
            builder.ToTable("ProjectUpdate");

            // Configure primary key
            builder.HasKey(p => p.UpdateID);

            // Configure properties
            builder.Property(p => p.ProjectID);

            builder.Property(p => p.Description);

            builder.Property(p => p.IsActive);

            builder.Property(p => p.CreatedBy);

            builder.Property(p => p.CreatedDate);

            builder.Property(p => p.LastModifiedBy);

            builder.Property(p => p.LastModifiedDate);

            builder.Property(p => p.ProjectImage)
                .HasColumnType("varchar(max)");
        }
    }
}
