using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class InformationConfiguration : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.ToTable("tbl_Infomation");

            builder.HasKey(a => a.InfId);

            builder.Property(a => a.InfId)
                .HasColumnName("InfId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.InfType)
                .HasColumnName("InfType")
                .HasColumnType("Varchar(20)");

            builder.Property(a => a.InfDesc)
                .HasColumnName("InfDesc")
                .HasColumnType("Varchar(80)");
        }
    }
}
