using Azure.Core;
using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;

namespace HubTown_Client_Protal_Backend.Api.Application.Services
{
    public class AuthsService(IAuthsRepository _AuthsRepository) : IAuthsService
    {
        public Task<string> GetJWTToken(Guid userId, CancellationToken cancellationToken = default)
        {
            //if (IsValidUser(userId))
            //{
            return _AuthsRepository.GetJWTToken(userId, cancellationToken);
            //}
            //else
            //{
            //    return Task.FromResult(string.Empty);
            //}
        }
        public Task<GetOTPResponse> GetOTP(GetOTPRequest request, CancellationToken cancellationToken = default)
        {
            return _AuthsRepository.GetOTP(request, cancellationToken);
        }
        public Task<VerifyOTPResponse> VerifyOTP(VerifyOTPRequest request, CancellationToken cancellationToken = default)
        {
            return _AuthsRepository.VerifyOTP(request, cancellationToken);
        }

        public Task<object> VerifyAdminCredentialsAsync(VerifyAdminRequest request, CancellationToken cancellationToken = default)
        {
            return _AuthsRepository.VerifyAdminCredentialsAsync(request, cancellationToken);
        }


        public async Task<List<object>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _AuthsRepository.GetUsersAsync(cancellationToken);
        }


        //private bool IsValidUser(string userId)
        //{
        //    // Replace with your actual user validation logic
        //    // For example, check if the userId exists in your database
        //    return !string.IsNullOrEmpty(userId);
        //}
    }
}
