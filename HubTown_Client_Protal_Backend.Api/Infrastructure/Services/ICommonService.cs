namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Services
{
    public interface ICommonService
    {
        Task<string> GenerateOtp(int length);
    }
}
