using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HubTown_Client_Protal_Backend.Api.Application.Services
{
    public class BookingService(IBookingRepository _BookingRepository) : IBookingService
    {
        //public Task<string> GetPropertyList(CancellationToken cancellationToken = default)
        //{
        //    return _BookingRepository.GetPropertyList(cancellationToken);
        //}

        //public Task<string> GetPropertyDetails(CancellationToken cancellationToken = default)
        //{
        //    return _BookingRepository.GetPropertyDetails(cancellationToken);
        //}

        //public Task<string> GetMilestoneDetails(CancellationToken cancellationToken = default)
        //{
        //    return _BookingRepository.GetMilestoneDetails(cancellationToken);
        //}

        //public Task<string> GetDemandDetails(CancellationToken cancellationToken = default)
        //{
        //    return _BookingRepository.GetDemandDetails(cancellationToken);
        //}

        //public Task<string> GetReceiptsDetails(CancellationToken cancellationToken = default)
        //{
        //    return _BookingRepository.GetReceiptsDetails(cancellationToken);
        //}

        //public Task<string> GetHomeLoanNOCDetails(CancellationToken cancellationToken = default)
        //{
        //    return _BookingRepository.GetHomeLoanNOCDetails(cancellationToken);
        //}
        //Added By Shubham
        public Task<List<DemandBreakup>> GetDemandBreakup(int? BookingID, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetDemandBreakup(BookingID, cancellationToken);
        }
        public Task<List<accountSummary>> GetAccountSummary(int? BookingID, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetAccountSummary(BookingID, cancellationToken);
        }
        public Task<List<BankAccount>> GetBankPayableAccounts(int? BookingID, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetBankPayableAccounts(BookingID, cancellationToken);
        }
        public Task<List<DemandLetter>> GetDemandLetters(int? BookingID, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetDemandLetters(BookingID, cancellationToken);
        }
        //Ended By Shubham
        public Task<List<Booking>> GetBooking([FromQuery] Guid? UserID, [FromQuery] int? ProjectID, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetBooking(UserID, ProjectID, cancellationToken);
        }
        public Task<List<GetCoOwnerResponse>> GetCoOwner([FromQuery] Guid? UserID, [FromQuery] int? BookingID, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetCoOwner(UserID, BookingID, cancellationToken);
        }
        public Task<List<Receipt>> GetReceipts(int? BookingId, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetReceipts(BookingId, cancellationToken);
        }

        public Task<List<HomeLoanNoc>> GetHomeLoanNOC(int? BookingId, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetHomeLoanNOC(BookingId, cancellationToken);
        }

        public Task<List<Milestone>> GetMilestones(int? BookingId, CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetMilestones(BookingId, cancellationToken);
        }
        public Task<List<Project>> GetUpcomingProject(CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetUpcomingProject(cancellationToken);
        }

        public Task<List<ProjectUpdate>> GetProjectUpdates(int projectid,CancellationToken cancellationToken = default)
        {
            return _BookingRepository.GetProjectUpdates(projectid,cancellationToken);
        }
    }
}
