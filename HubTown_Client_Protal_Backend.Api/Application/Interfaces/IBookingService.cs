using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HubTown_Client_Protal_Backend.Api.Application.Interfaces
{
    public interface IBookingService
    {
        //Task<string> GetPropertyList(CancellationToken cancellationToken = default);
        //Task<string> GetPropertyDetails(CancellationToken cancellationToken = default);
        //Task<string> GetMilestoneDetails(CancellationToken cancellationToken = default);
        //Task<string> GetDemandDetails(CancellationToken cancellationToken = default);
        //Task<string> GetReceiptsDetails(CancellationToken cancellationToken = default);
        //Task<string> GetHomeLoanNOCDetails(CancellationToken cancellationToken = default);
        Task<List<DemandBreakup>> GetDemandBreakup(int? BookingID, CancellationToken cancellationToken = default); //Added By Shubham
        Task<List<accountSummary>> GetAccountSummary(int? BookingID, CancellationToken cancellationToken = default); //Added By Shubham
        Task<List<BankAccount>> GetBankPayableAccounts(int? BookingID, CancellationToken cancellationToken = default); //Added By Shubham
        Task<List<DemandLetter>> GetDemandLetters(int? BookingID, CancellationToken cancellationToken = default); //Added By Shubham
        Task<List<Booking>> GetBooking([FromQuery] Guid? UserID, [FromQuery] int? ProjectID, CancellationToken cancellationToken = default);
        Task<List<GetCoOwnerResponse>> GetCoOwner([FromQuery] Guid? UserID, [FromQuery] int? BookingID, CancellationToken cancellationToken = default);
        Task<List<Receipt>> GetReceipts(int? BookingId, CancellationToken cancellationToken = default);
        Task<List<HomeLoanNoc>> GetHomeLoanNOC(int? BookingId, CancellationToken cancellationToken = default);
        Task<List<Milestone>> GetMilestones(int? BookingId, CancellationToken cancellationToken = default);
        Task<List<Project>> GetUpcomingProject(CancellationToken cancellationToken = default);
        Task<List<ProjectUpdate>> GetProjectUpdates(int projectid, CancellationToken cancellationToken = default);
    }
}
