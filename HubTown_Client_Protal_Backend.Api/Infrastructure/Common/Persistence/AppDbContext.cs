using HubTown_Client_Protal_Backend.Api.Domain.Configurations;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<AccountSummary> accountsummarys { get; set; }
        public virtual DbSet<BankAccount> bankaccounts { get; set; }
        public virtual DbSet<Booking> bookings { get; set; }
        public virtual DbSet<DemandBreakup> demandbreakups { get; set; }
        public virtual DbSet<DemandLetter> demandletters { get; set; }
        public virtual DbSet<HomeLoanNoc> homeloannocs { get; set; }
        public virtual DbSet<Image> images { get; set; }
        public virtual DbSet<KycUpload> kycuploads { get; set; }
        public virtual DbSet<Milestone> milestones { get; set; }
        public virtual DbSet<Notification> notifications { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Project> projects { get; set; }
        public virtual DbSet<Receipt> receipt { get; set; }
        public virtual DbSet<Tds> tdss { get; set; }
        public virtual DbSet<UnitOwner> unitowners { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<UserLogin> userlogins { get; set; }

        public virtual DbSet<CategoryMaster> categoryMasters { get; set; }
        public virtual DbSet<ProjectUpdate> ProjectUpdate { get; set; }

        public virtual DbSet<ProjectImages> ProjectImages { get; set; }

        public virtual DbSet<ProjectUpdateImages> ProjectUpdateImages { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Information> Informations { get; set; }

        public DbSet<OtpAuditLog> OtpAuditLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountSummaryConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new DemandBreakupConfiguration());
            modelBuilder.ApplyConfiguration(new DemandLetterConfiguration());
            modelBuilder.ApplyConfiguration(new HomeLoanNocConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new KycUploadConfiguration());
            modelBuilder.ApplyConfiguration(new MilestoneConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new TdsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new FaqConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectUpdateConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectUpdateImagesConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectImagesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryMasterConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new InformationConfiguration());
            modelBuilder.ApplyConfiguration(new OtpAuditLogConfiguration());
        }
    }
}