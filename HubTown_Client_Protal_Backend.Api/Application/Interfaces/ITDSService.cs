using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;

namespace HubTown_Client_Protal_Backend.Api.Application.Interfaces
{
    public interface ITDSService
    {
        Task<IEnumerable<Tds>> GetTDSDetails(int BookingId, CancellationToken cancellationToken = default);
        Task<string> UploadTDS(UploadTDSFileRequest request, CancellationToken cancellationToken = default);

        //Task<IEnumerable<Tds>> GetTDS(int BookingId, CancellationToken cancellationToken = default);

    }
}

