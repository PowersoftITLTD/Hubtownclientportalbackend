using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;

namespace HubTown_Client_Protal_Backend.Api.Application.Services
{
    public class TDSService(ITDSRepository _TDSRepository) : ITDSService
    {
        public Task<IEnumerable<Tds>> GetTDSDetails(int BookingId, CancellationToken cancellationToken = default)
        {
            return _TDSRepository.GetTDSDetails(BookingId, cancellationToken);
        }

        public Task<string> UploadTDS(UploadTDSFileRequest request, CancellationToken cancellationToken = default)
        {
            return _TDSRepository.UploadTDS(request, cancellationToken);
        }
        //public async Task<IEnumerable<Tds>> GetTDS(int BookingId, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return await _TDSRepository.GetTDS(BookingId, cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exception as needed
        //        throw;
        //    }
        //}
    }
}
