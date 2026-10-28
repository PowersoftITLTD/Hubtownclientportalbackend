using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_images");

            // Configure primary key
            builder.HasKey(i => i.ImageId);

            // Configure columns
            builder.Property(i => i.ImageId)
                .HasColumnName("ImageId");

            builder.Property(i => i.ProjectId)
                .HasColumnName("ProjectId")
                .IsRequired();

            builder.Property(i => i.ImageUrl)
                .HasColumnName("ImageUrl")
                .HasMaxLength(50);

            builder.Property(i => i.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(i => i.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(i => i.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(i => i.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(i => i.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Project)
                .WithMany() // Assuming there is no collection property on Project for Image
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
