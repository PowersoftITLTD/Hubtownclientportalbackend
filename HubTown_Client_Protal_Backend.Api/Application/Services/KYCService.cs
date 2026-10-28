using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;

namespace HubTown_Client_Protal_Backend.Api.Application.Services
{
    public class KYCService(IKYCRepository _KYCRepository) : IKYCService
    {
        public Task<IEnumerable<KycUpload>> GetKYCDetails(int BookingID, CancellationToken cancellationToken = default)
        {
            return _KYCRepository.GetKYCDetails(BookingID, cancellationToken);
        }

        public Task<string> UploadKYC(UploadKYCFileRequest request, CancellationToken cancellationToken = default)
        {
            return _KYCRepository.UploadKYC(request, cancellationToken);
        }

        public Task<string> DeleteKYC(Guid kycid, CancellationToken cancellationToken = default)
        {
            return _KYCRepository.DeleteKYC(kycid, cancellationToken);
        }
    }
}
