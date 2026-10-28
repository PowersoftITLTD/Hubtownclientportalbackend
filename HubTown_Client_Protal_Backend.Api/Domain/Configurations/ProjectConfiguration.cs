using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_projects");

            // Configure primary key
            builder.HasKey(p => p.ProjectId);

            // Configure columns
            builder.Property(p => p.ProjectId)
                .HasColumnName("ProjectId");

            builder.Property(p => p.ProjectName)
                .HasColumnName("ProjectName")
                .HasMaxLength(30);

            builder.Property(p => p.Status)
                .HasColumnName("Status")
                .HasMaxLength(30);

            builder.Property(p => p.ProjectLogoUrl)
                .HasColumnName("ProjectLogoUrl")
                .HasMaxLength(50);

            builder.Property(p => p.Rerano)
                .HasColumnName("Rerano")
                .HasColumnType("varchar(max)");

            builder.Property(p => p.ReraDocument)
                .HasColumnName("ReraDocument")
                .HasColumnType("varchar(max)");

            builder.Property(p => p.ReraLink)
                .HasColumnName("ReraLink")
                .HasMaxLength(30);

            builder.Property(p => p.Address)
                .HasColumnName("Address")
                .HasMaxLength(500);

            builder.Property(p => p.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(p => p.IsUcomming)
               .HasColumnName("IsUcomming")
               .HasDefaultValue(false);

            builder.Property(p => p.Facebooklink)
            .HasColumnName("Facebooklink")
            .HasColumnType("varchar(max)");

            builder.Property(p => p.Instagramlink)
            .HasColumnName("Instagramlink")
            .HasColumnType("varchar(max)");

            builder.Property(p => p.websiteLink)
         .HasColumnName("websiteLink")
         .HasColumnType("varchar(max)");

            builder.Property(p => p.ProjectImage)
            .HasColumnName("ProjectImage")
            .HasColumnType("varchar(max)");

            builder.Property(p => p.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(p => p.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(p => p.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(p => p.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");
        }
    }
}
