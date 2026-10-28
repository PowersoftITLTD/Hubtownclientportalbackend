using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubTown_Client_Protal_Backend.Api.Migrations
{
    /// <inheritdoc />
    public partial class HubtownCLientportal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectLogoUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rerano = table.Column<string>(type: "varchar(max)", nullable: false),
                    ReraDocument = table.Column<string>(type: "varchar(max)", nullable: false),
                    ReraLink = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CurrentOTP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OTPExpiry = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    OCNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OCDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Building = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CarPark = table.Column<int>(type: "int", nullable: true),
                    UnitType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OutstandingWithinDueAmount = table.Column<decimal>(type: "money", nullable: true),
                    OutstandingOverdueAmount = table.Column<decimal>(type: "money", nullable: true),
                    TDSOutstanding = table.Column<decimal>(type: "money", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegistrationActualDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegistrationTentativeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FitoutDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PossessionFinalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RmEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RmContact = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_tbl_booking_tbl_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "tbl_projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_tbl_images_tbl_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "tbl_projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserLogin",
                columns: table => new
                {
                    LoginID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UsedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserLogin", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_tbl_UserLogin_tbl_users_UserID",
                        column: x => x.UserID,
                        principalTable: "tbl_users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AccountSummary",
                columns: table => new
                {
                    AccountSummaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    FC_DemandLetterRaised_Amount = table.Column<decimal>(type: "money", nullable: false),
                    FC_DemandLetterRaised_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    SC_DemandLetterRaised_Amount = table.Column<decimal>(type: "money", nullable: false),
                    SC_DemandLetterRaised_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    INT_DemandLetterRaised_Amount = table.Column<decimal>(type: "money", nullable: false),
                    INT_DemandLetterRaised_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    Undjusted_DemandLetter = table.Column<decimal>(type: "money", nullable: false),
                    FC_DiscountDemandLetter_Amount = table.Column<decimal>(type: "money", nullable: false),
                    FC_DiscountDemandLetter_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    SC_DiscountDemandLetter_Amount = table.Column<decimal>(type: "money", nullable: false),
                    SC_DiscountDemandLetter_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    INT_DiscountDemandLetter_Amount = table.Column<decimal>(type: "money", nullable: false),
                    INT_DiscountDemandLetter_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    Undjusted_DiscountDemandLetter = table.Column<decimal>(type: "money", nullable: false),
                    FC_Receipts_Amount = table.Column<decimal>(type: "money", nullable: false),
                    FC_Receipts_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    SC_Receipts_Amount = table.Column<decimal>(type: "money", nullable: false),
                    SC_Receipts_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    INT_Receipts_Amount = table.Column<decimal>(type: "money", nullable: false),
                    INT_Receipts_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    Undjusted_Receipts = table.Column<decimal>(type: "money", nullable: false),
                    FC_TransferAdjusted_Amount = table.Column<decimal>(type: "money", nullable: false),
                    FC_TransferAdjusted_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    SC_TransferAdjusted_Amount = table.Column<decimal>(type: "money", nullable: false),
                    SC_TransferAdjusted_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    INT_TransferAdjusted_Amount = table.Column<decimal>(type: "money", nullable: false),
                    INT_TransferAdjusted_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    Undjusted_TransferAdjusted = table.Column<decimal>(type: "money", nullable: false),
                    FC_TDS_Amount = table.Column<decimal>(type: "money", nullable: false),
                    SC_TDS_Amount = table.Column<decimal>(type: "money", nullable: false),
                    INT_TDS_Amount = table.Column<decimal>(type: "money", nullable: false),
                    Undjusted_TDS = table.Column<decimal>(type: "money", nullable: false),
                    FC_Payable_Amount = table.Column<decimal>(type: "money", nullable: false),
                    FC_Payable_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    SC_Payable_Amount = table.Column<decimal>(type: "money", nullable: false),
                    SC_Payable_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    INT_Payable_Amount = table.Column<decimal>(type: "money", nullable: false),
                    INT_Payable_Taxes = table.Column<decimal>(type: "money", nullable: false),
                    Undjusted_Payable = table.Column<decimal>(type: "money", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AccountSummary", x => x.AccountSummaryID);
                    table.ForeignKey(
                        name: "FK_tbl_AccountSummary_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bankAccounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IFSCCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bankAccounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_tbl_bankAccounts_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_demandBreakup",
                columns: table => new
                {
                    BreakupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    FlatConsiderationAmt = table.Column<decimal>(type: "money", nullable: false),
                    SocietyCharges = table.Column<decimal>(type: "money", nullable: false),
                    Society = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatutoryRequirements = table.Column<decimal>(type: "money", nullable: false),
                    TotalWoTax = table.Column<decimal>(type: "money", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_demandBreakup", x => x.BreakupID);
                    table.ForeignKey(
                        name: "FK_tbl_demandBreakup_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DemandLetter",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDescription = table.Column<string>(type: "varchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InvoiceAmt = table.Column<decimal>(type: "money", nullable: false),
                    InvoiceUrl = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false) ,
                    url = table.Column<string>(type: "varchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DemandLetter", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_tbl_DemandLetter_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_HomeLoanNoc",
                columns: table => new
                {
                    NOCID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    NocDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NocUrl = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HomeLoanNoc", x => x.NOCID);
                    table.ForeignKey(
                        name: "FK_tbl_HomeLoanNoc_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_kycUpload",
                columns: table => new
                {
                    KycId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DocumentFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_kycUpload", x => x.KycId);
                    table.ForeignKey(
                        name: "FK_tbl_kycUpload_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Milestone",
                columns: table => new
                {
                    MilestoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    MileStoneName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    TentativeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrentMS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    MilestoneDocUrl = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Milestone", x => x.MilestoneId);
                    table.ForeignKey(
                        name: "FK_tbl_Milestone_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    NotificationPayload = table.Column<string>(type: "varchar(max)", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_tbl_Notifications_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Receipts",
                columns: table => new
                {
                    ReceiptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReceiptNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReceiptAmt = table.Column<decimal>(type: "money", nullable: false),
                    ReceiptUrl = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Receipts", x => x.ReceiptID);
                    table.ForeignKey(
                        name: "FK_tbl_Receipts_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tds",
                columns: table => new
                {
                    TDSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    TDSDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TDSAmount = table.Column<decimal>(type: "money", nullable: false),
                    TDSFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tds", x => x.TDSId);
                    table.ForeignKey(
                        name: "FK_tbl_Tds_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unitowners",
                columns: table => new
                {
                    UnitOwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnershipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitowners", x => x.UnitOwnerID);
                    table.ForeignKey(
                        name: "FK_unitowners_tbl_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "tbl_booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unitowners_tbl_users_UserID",
                        column: x => x.UserID,
                        principalTable: "tbl_users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AccountSummary_BookingID",
                table: "tbl_AccountSummary",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bankAccounts_BookingID",
                table: "tbl_bankAccounts",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_booking_ProjectId",
                table: "tbl_booking",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_demandBreakup_BookingID",
                table: "tbl_demandBreakup",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DemandLetter_BookingID",
                table: "tbl_DemandLetter",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HomeLoanNoc_BookingID",
                table: "tbl_HomeLoanNoc",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_images_ProjectId",
                table: "tbl_images",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_kycUpload_BookingID",
                table: "tbl_kycUpload",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Milestone_BookingID",
                table: "tbl_Milestone",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Notifications_BookingID",
                table: "tbl_Notifications",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Receipts_BookingID",
                table: "tbl_Receipts",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tds_BookingID",
                table: "tbl_Tds",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserLogin_UserID",
                table: "tbl_UserLogin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_unitowners_BookingID",
                table: "unitowners",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_unitowners_UserID",
                table: "unitowners",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AccountSummary");

            migrationBuilder.DropTable(
                name: "tbl_bankAccounts");

            migrationBuilder.DropTable(
                name: "tbl_demandBreakup");

            migrationBuilder.DropTable(
                name: "tbl_DemandLetter");

            migrationBuilder.DropTable(
                name: "tbl_HomeLoanNoc");

            migrationBuilder.DropTable(
                name: "tbl_images");

            migrationBuilder.DropTable(
                name: "tbl_kycUpload");

            migrationBuilder.DropTable(
                name: "tbl_Milestone");

            migrationBuilder.DropTable(
                name: "tbl_Notifications");

            migrationBuilder.DropTable(
                name: "tbl_Receipts");

            migrationBuilder.DropTable(
                name: "tbl_Tds");

            migrationBuilder.DropTable(
                name: "tbl_UserLogin");

            migrationBuilder.DropTable(
                name: "unitowners");

            migrationBuilder.DropTable(
                name: "tbl_booking");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_projects");
        }
    }
}
