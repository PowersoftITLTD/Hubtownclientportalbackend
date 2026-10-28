using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;

namespace HubTown_Client_Protal_Backend.Api.Application.Interfaces
{
    public interface IKYCService
    {
        Task<IEnumerable<KycUpload>> GetKYCDetails(int BookingID, CancellationToken cancellationToken = default);
        Task<string> UploadKYC(UploadKYCFileRequest request, CancellationToken cancellationToken = default);
        Task<string> DeleteKYC(Guid kycid, CancellationToken cancellationToken = default);

    }
}
