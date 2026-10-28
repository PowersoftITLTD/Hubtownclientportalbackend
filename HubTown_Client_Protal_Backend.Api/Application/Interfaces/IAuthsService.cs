using HubTown_Client_Protal_Backend.Api.Application.DTOs;

namespace HubTown_Client_Protal_Backend.Api.Application.Interfaces
{
    public interface IAuthsService
    {
        Task<string> GetJWTToken(Guid userId, CancellationToken cancellationToken = default);
        Task<GetOTPResponse> GetOTP(GetOTPRequest request, CancellationToken cancellationToken = default);
        Task<VerifyOTPResponse> VerifyOTP(VerifyOTPRequest request, CancellationToken cancellationToken = default);
        Task<object> VerifyAdminCredentialsAsync(VerifyAdminRequest request, CancellationToken cancellationToken = default);
        Task<List<object>> GetUsersAsync(CancellationToken cancellationToken = default);
    }
}
