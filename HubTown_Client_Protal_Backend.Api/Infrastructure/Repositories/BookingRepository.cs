using ErrorOr;
using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Sockets;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories
{
    public class BookingRepository(AppDbContext _AppDbContext) : IBookingRepository
    {
        //public async Task<string> GetPropertyList(CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return "";
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<string> GetPropertyDetails(CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return "";
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<string> GetMilestoneDetails(CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return "";
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<string> GetDemandDetails(CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return "";
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<string> GetReceiptsDetails(CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return "";
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<string> GetHomeLoanNOCDetails(CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return "";
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //}
        //Added By Shubham
        public async Task<List<DemandBreakup>> GetDemandBreakup(int? BookingID, CancellationToken cancellationToken = default)
        {
            try
            {
                List<DemandBreakup> Dmndbrkplst = new List<DemandBreakup>();
                var breakupSummary = await _AppDbContext.demandbreakups
           .Where(d => d.BookingID == BookingID)
           .GroupBy(d => d.BookingID)
           .Select(g => new DemandBreakup
           {
               BookingID = g.Key,
               FlatConsiderationAmt = g.Sum(x => x.FlatConsiderationAmt),
               SocietyCharges = g.Sum(x => x.SocietyCharges),
               Society = g.First().Society,
               StatutoryRequirements = g.Sum(x => x.StatutoryRequirements),
               TotalWoTax = g.Sum(x => x.TotalWoTax),
               GroupA_Caption = g.First().GroupA_Caption,
               GroupB_Caption = g.First().GroupB_Caption,
               GroupC_Caption = g.First().GroupC_Caption,
               GroupD_Caption = g.First().GroupD_Caption,
               IsActive = g.First().IsActive,  // Assuming isActive is the same for all entries
               CreatedBy = g.First().CreatedBy,  // Keep the createdBy of the first entry
               CreatedAt = g.First().CreatedAt,  // Keep the createdAt of the first entry
               ModifiedBy = g.First().ModifiedBy,  // Keep the modifiedBy of the first entry
               ModifiedAt = g.First().ModifiedAt  // Keep the modifiedAt of the first entry
           })
           .FirstOrDefaultAsync(cancellationToken);

                Dmndbrkplst.Add(breakupSummary);
                return Dmndbrkplst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<accountSummary>> GetAccountSummary(int? BookingID, CancellationToken cancellationToken = default)
        {
            try
            {
                var accountSummary = await _AppDbContext.accountsummarys
                    .Where(d => d.BookingID == BookingID)
                    .FirstOrDefaultAsync(cancellationToken);

                if (accountSummary == null)
                    return null;


                var accountSummaryList = new List<accountSummary>
        {
            CreateAccountSummary("Demand Letter Amount Raised",
                accountSummary.FC_DemandLetterRaised_Amount, accountSummary.FC_DemandLetterRaised_Taxes,
                accountSummary.SC_DemandLetterRaised_Amount, accountSummary.SC_DemandLetterRaised_Taxes,
                accountSummary.INT_DemandLetterRaised_Amount, accountSummary.INT_DemandLetterRaised_Taxes,
                accountSummary.Undjusted_DemandLetter),

            CreateAccountSummary("Discount on Demand Letter",
                accountSummary.FC_DiscountDemandLetter_Amount, accountSummary.FC_DiscountDemandLetter_Taxes,
                accountSummary.SC_DiscountDemandLetter_Amount, accountSummary.SC_DiscountDemandLetter_Taxes,
                accountSummary.INT_DiscountDemandLetter_Amount, accountSummary.INT_DiscountDemandLetter_Taxes,
                accountSummary.Undjusted_DiscountDemandLetter),

            CreateAccountSummary("Receipts",
                accountSummary.FC_Receipts_Amount, accountSummary.FC_Receipts_Taxes,
                accountSummary.SC_Receipts_Amount, accountSummary.SC_Receipts_Taxes,
                accountSummary.INT_Receipts_Amount, accountSummary.INT_Receipts_Taxes,
                accountSummary.Undjusted_Receipts),

            CreateAccountSummary("Transfer Adjusted",
                accountSummary.FC_TransferAdjusted_Amount, accountSummary.FC_TransferAdjusted_Taxes,
                accountSummary.SC_TransferAdjusted_Amount, accountSummary.SC_TransferAdjusted_Taxes,
                accountSummary.INT_TransferAdjusted_Amount, accountSummary.INT_TransferAdjusted_Taxes,
                accountSummary.Undjusted_TransferAdjusted),

            CreateAccountSummary("TDS Amount Received",
                accountSummary.FC_TDS_Amount, 0,
                accountSummary.SC_TDS_Amount, 0,
                accountSummary.INT_TDS_Amount, 0,
                accountSummary.Undjusted_TDS),

            CreateAccountSummary("Amount Payable",
                accountSummary.FC_Payable_Amount, accountSummary.FC_Payable_Taxes,
                accountSummary.SC_Payable_Amount, accountSummary.SC_Payable_Taxes,
                accountSummary.INT_Payable_Amount, accountSummary.INT_Payable_Taxes,
                accountSummary.Undjusted_Payable)
        };

                return accountSummaryList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private accountSummary CreateAccountSummary(string particulars,
            decimal fcAmount, decimal fcTaxes,
            decimal scAmount, decimal scTaxes,
            decimal intAmount, decimal intTaxes,
            decimal unadjusted)
        {
            return new accountSummary
            {
                Particulars = particulars,
                FlatConsideration = new FlatConsideration
                {
                    Amount = fcAmount,
                    Taxes = fcTaxes
                },
                SocietyCharges = new Charges
                {
                    Amount = scAmount,
                    Taxes = scTaxes
                },
                InterestOthers = new InterestOthers
                {
                    Amount = intAmount,
                    Taxes = intTaxes
                },
                Unadjusted = new Unadjusted
                {
                    unadjusted = unadjusted
                }
            };
        }

        public async Task<List<BankAccount>> GetBankPayableAccounts(int? BookingID, CancellationToken cancellationToken = default)
        {
            try
            {

                return await _AppDbContext.bankaccounts
                    .Where(d => d.BookingID == BookingID)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<DemandLetter>> GetDemandLetters(int? BookingID, CancellationToken cancellationToken = default)
        {
            try
            {

                return await _AppDbContext.demandletters
                    .Where(d => d.BookingID == BookingID).OrderByDescending(d => d.InvoiceDate)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //Ended By Shubham
        public async Task<List<Booking>> GetBooking([FromQuery] Guid? UserID, [FromQuery] int? ProjectID, CancellationToken cancellationToken = default)
        {
            List<Booking> bookings = new List<Booking>();
            try
            {

                bookings = await _AppDbContext.unitowners
                                    .Where(uo => uo.UserID == UserID && uo.Booking.ProjectId == ProjectID && uo.Booking.Status == "Active")
                                    .Include(uo => uo.Booking)
                                      .Select(uo => new Booking
                                      {
                                          BookingID = uo.Booking.BookingID,
                                          ProjectId = uo.Booking.ProjectId,
                                          OCNo = uo.Booking.OCNo,
                                          OCDate = uo.Booking.OCDate,
                                          Status = uo.Booking.Status,
                                          Building = uo.Booking.Building,
                                          Unit = uo.Booking.Unit,
                                          Area = uo.Booking.Area,
                                          Floor = uo.Booking.Floor,
                                          CarPark = uo.Booking.CarPark,
                                          UnitType = uo.Booking.UnitType,
                                          OutstandingWithinDueAmount = uo.Booking.OutstandingWithinDueAmount,
                                          OutstandingOverdueAmount = uo.Booking.OutstandingOverdueAmount,
                                          TDSOutstanding = uo.Booking.TDSOutstanding,
                                          RegistrationNumber = uo.Booking.RegistrationNumber,
                                          RegistrationActualDate = uo.Booking.RegistrationActualDate,
                                          RegistrationTentativeDate = uo.Booking.RegistrationTentativeDate,
                                          FitoutDate = uo.Booking.FitoutDate,
                                          PossessionFinalDate = uo.Booking.PossessionFinalDate,
                                          RmName = uo.Booking.RmName,
                                          RmEmail = uo.Booking.RmEmail,
                                          RmContact = uo.Booking.RmContact
                                      })
                                    .ToListAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                bookings = new List<Booking>();
            }
            finally
            {
                await _AppDbContext.Database.CloseConnectionAsync();
            }
            return bookings;
        }
        public async Task<List<GetCoOwnerResponse>> GetCoOwner([FromQuery] Guid? UserID, [FromQuery] int? BookingID, CancellationToken cancellationToken = default)
        {
            List<GetCoOwnerResponse> coOwners = new List<GetCoOwnerResponse>();
            try
            {
                using (var command = _AppDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "GetBookingWithCoOwners";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@UserID", UserID));
                    command.Parameters.Add(new SqlParameter("@BookingID", BookingID));

                    await _AppDbContext.Database.OpenConnectionAsync();

                    using (var result = await command.ExecuteReaderAsync())
                    {
                        while (await result.ReadAsync())
                        {
                            coOwners.Add(new GetCoOwnerResponse
                            {
                                BookingID = result.GetInt32(0),
                                UserID = result.GetGuid(1),
                                Name = result.GetString(2),
                                Email = result.GetString(3),
                                Mobile = result.GetString(4),
                                ownerShipType = result.GetString(5),
                            });
                        }
                    }

                    await _AppDbContext.Database.CloseConnectionAsync();
                }
            }
            catch (Exception ex)
            {
                coOwners = new List<GetCoOwnerResponse>();
            }
            finally
            {
                await _AppDbContext.Database.CloseConnectionAsync();
            }
            return coOwners;
        }
        public async Task<List<Receipt>> GetReceipts(int? BookingID, CancellationToken cancellationToken = default)
        {
            try
            {

                return await _AppDbContext.receipt
                    .Where(d => d.BookingID == BookingID).OrderByDescending(d => d.ReceiptDate)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<HomeLoanNoc>> GetHomeLoanNOC(int? BookingId, CancellationToken cancellationToken = default)
        {
            try
            {
                var homeLoanNocDetails = await _AppDbContext.homeloannocs
                    .Where(noc => noc.BookingID == BookingId)
                    .ToListAsync(cancellationToken);

                return homeLoanNocDetails;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as required
                throw;
            }
        }

        public async Task<List<Milestone>> GetMilestones(int? BookingId, CancellationToken cancellationToken = default)
        {
            try
            {
                var milestoneDetails = await _AppDbContext.milestones
                 .Where(m => m.BookingID == BookingId).OrderBy(m => m.Sequenceno)
                 .ToListAsync(cancellationToken);

                var flatConsiderationamount = await _AppDbContext.demandbreakups
                    .Where(x => x.BookingID == BookingId).Select(x => x.FlatConsiderationAmt)
                    .FirstOrDefaultAsync();

                //var accountSummary = await _AppDbContext.accountsummarys
                //    .Where(x => x.BookingID == BookingId)
                //    .FirstOrDefaultAsync();

                //if (accountSummary != null)
                //{
                //    // Calculate the totalAmount from accountSummary
                //    decimal totalAmount = accountSummary.FC_DemandLetterRaised_Amount +
                //                          accountSummary.FC_DemandLetterRaised_Taxes +
                //                          accountSummary.SC_DemandLetterRaised_Amount +
                //                          accountSummary.SC_DemandLetterRaised_Taxes;

                //    // Set totalAmount in each milestone object and calculate the percentage-based amount
                if (flatConsiderationamount != null)
                {
                    milestoneDetails.ForEach(m =>
                {
                    m.flatConsiderationamount = flatConsiderationamount;
                });
                }

                return milestoneDetails;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as required
                throw;
            }
        }

        public async Task<List<Project>> GetUpcomingProject(CancellationToken cancellationToken = default)
        {
            try
            {
                var upcomingProjects = _AppDbContext.projects.Include(x => x.ListProjectImages).Include(x => x.booking).Where(p => p.Status == "Active" && p.IsActive == true && p.IsUcomming == true).ToList();

                return upcomingProjects;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProjectUpdate>> GetProjectUpdates(int projectid, CancellationToken cancellationToken = default)
        {
            try
            {
                var projectUpdates = _AppDbContext.ProjectUpdate
                                    .Where(p => p.IsActive == true && p.ProjectID == projectid)
                                    .Include(p => p.ProjectUpdateImages)
                                    .Include(p => p.Project) // Include the Project entity
                                    .ToList();


                return projectUpdates;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
