using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;

namespace HubTown_Client_Protal_Backend.Api.Application.Services
{
    public class FeedbackService(IFeedbackRepository _feedbackRepository) : IFeedbackService
    {
        public async Task<List<Information>> GetInformationList(CancellationToken cancellationToken = default)
        {
            return await _feedbackRepository.GetInformationList(cancellationToken);
        }
        public async Task<dynamic> SaveFeedback(FeedbackRequest request, CancellationToken cancellationToken = default)
        {
            return await _feedbackRepository.SaveFeedback(request, cancellationToken);
        }
        public async Task<FeedbackRequest> GetFeedback(GetFeedbackRequest request, CancellationToken cancellationToken = default)
        {
            return await _feedbackRepository.GetFeedback(request, cancellationToken);
        }
    }
}
