using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;

namespace HubTown_Client_Protal_Backend.Api.Domain.IRepositories
{
    public interface IFeedbackRepository
    {
        Task<List<Information>> GetInformationList(CancellationToken cancellationToken = default);
        Task<dynamic> SaveFeedback(FeedbackRequest request, CancellationToken cancellationToken = default);
        Task<FeedbackRequest> GetFeedback(GetFeedbackRequest request, CancellationToken cancellationToken = default);
    }
}
