using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("tbl_feedback");

            builder.HasKey(a => a.FeedbackID);

            builder.Property(a => a.FeedbackID)
                .HasColumnName("FeedbackID")
                .HasColumnType("BIGINT");

            builder.Property(a => a.BuildingName)
                .HasColumnName("BuildingName")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(a => a.UnitNo)
                .HasColumnName("UnitNo")
                .HasColumnType("varchar(20)");
               

            builder.Property(a => a.InfId)
                .HasColumnName("InfId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.CustomerName)
                .HasColumnName("CustomerName")
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Comments)
                .HasColumnName("Comments")
                .HasColumnType("varchar(500)");

            builder.Property(a => a.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME");


            builder.Property(a => a.Source)
               .HasColumnName("Source")
               .HasColumnType("char(1)");

           


            builder.HasCheckConstraint("CK__tbl_feedb__Sourc__5555A4F4", "[Source] IS NULL OR [Source] IN ('C', 'F')");

            builder.HasOne(d => d.Information)
                   .WithMany()
                   .HasForeignKey(d => d.InfId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
