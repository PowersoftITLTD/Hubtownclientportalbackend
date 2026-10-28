using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Domain.Configurations
{
    public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
    {
        public void Configure(EntityTypeBuilder<Milestone> builder)
        {
            // Configure the table name if it's different from the class name
            builder.ToTable("tbl_Milestone");

            // Configure primary key
            builder.HasKey(m => m.MilestoneId);

            // Configure columns
            builder.Property(m => m.MilestoneId)
                .HasColumnName("MilestoneId");

            builder.Property(m => m.BookingID)
                .HasColumnName("BookingID")
                .IsRequired();

            builder.Property(m => m.MileStoneName)
                .HasColumnName("MileStoneName")
                .HasMaxLength(20);

            builder.Property(m => m.Amount)
                .HasColumnName("Amount")
                .HasColumnType("money");

            builder.Property(m => m.Pendingamount)
             .HasColumnName("Pendingamount")
             .HasColumnType("decimal(18,2)");

            builder.Property(m => m.Paidamount)
          .HasColumnName("Paidamount")
          .HasColumnType("decimal(18,2)");

            builder.Property(m => m.TentativeDate)
                .HasColumnName("TentativeDate")
                .HasColumnType("datetime");

            builder.Property(m => m.StartDate)
              .HasColumnName("StartDate")
              .HasColumnType("datetime");

            builder.Property(m => m.ActualDate)
                .HasColumnName("ActualDate")
                .HasColumnType("datetime");

            builder.Property(m => m.CurrentMS)
                .HasColumnName("CurrentMS")
                .HasMaxLength(1);

            builder.Property(m => m.MilestoneDocUrl)
                .HasColumnName("MilestoneDocUrl")
                .HasColumnType("varchar(max)");

            builder.Property(m => m.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder.Property(m => m.Sequenceno)
              .HasColumnName("Sequenceno");

            builder.Property(m => m.Totalamount)
            .HasColumnName("Totalamount")
            .HasColumnType("decimal(18,2)");


            builder.Property(m => m.Mile_Perc)
            .HasColumnName("Mile_Perc")
            .HasColumnType("numeric");

            builder.Property(m => m.Invoice)
         .HasColumnName("BalanceAmt")
         .HasColumnType("numeric");

            builder.Property(m => m.Reciept)
         .HasColumnName("ReceiptAmt")
         .HasColumnType("numeric");


            builder.Property(m => m.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(20);

            builder.Property(m => m.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");

            builder.Property(m => m.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(30);

            builder.Property(m => m.ModifiedAt)
                .HasColumnName("ModifiedAt")
                .HasColumnType("datetime");

            // Configure relationships
            builder.HasOne(d => d.Booking)
                .WithMany() // Assuming there is no collection property on Booking for Milestone
                .HasForeignKey(m => m.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
