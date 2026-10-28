using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories
{
    public class FeedbackRepository(AppDbContext _dbcontext) : IFeedbackRepository
    {
        public async Task<List<Information>> GetInformationList(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbcontext.Informations.ToListAsync();
            }
            catch (Exception Ex)
            {
                throw;
            }

        }
        public async Task<dynamic> SaveFeedback(FeedbackRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var Feedback = new Feedback()
                {
                    BuildingName = request.BuildingName,
                    UnitNo = request.UnitNo,
                    InfId = request.InfId,
                    CustomerName = request.CustomerName,
                    Comments = request.Comments,
                    CreatedAt = DateTime.Now,
                    Source = request.Source,
                };

                _dbcontext.Feedbacks.Add(Feedback);
                await _dbcontext.SaveChangesAsync();
                return new { Message = "Feedback sent Successfully" };
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
        public async Task<FeedbackRequest> GetFeedback(GetFeedbackRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await (from f in _dbcontext.Feedbacks
                                      where f.BuildingName == request.BuildingName
                                      && f.UnitNo == request.UnitNo
                                      && f.CustomerName == request.CustomerName
                                      select new FeedbackRequest
                                      {
                                          BuildingName = f.BuildingName,
                                          UnitNo = f.UnitNo,
                                          CustomerName = f.CustomerName,
                                          Comments = f.Comments,
                                          InfId = f.InfId,
                                          Source = f.Source,
                                      }).FirstOrDefaultAsync();

                return response;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
    }
}
