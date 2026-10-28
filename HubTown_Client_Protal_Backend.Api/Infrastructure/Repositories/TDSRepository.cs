using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories
{
    public class TDSRepository(AppDbContext _dbcontext, IDocument _document) : ITDSRepository
    {
        public async Task<IEnumerable<Tds>> GetTDSDetails(int BookingId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbcontext.tdss
                    .Where(t => t.BookingID == BookingId)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public async Task<string> UploadTDS(UploadTDSFileRequest request, CancellationToken cancellationToken = default)
        {
            string response = string.Empty;
            try
            {
                // Upload file using document service
                response = await _document.UploadAnyDocuemnts(request.UserID, request.File, "TDS", cancellationToken);

                if (!string.IsNullOrEmpty(response))
                {
                    Tds tds = new Tds
                    {
                        BookingID = request.BookingID,
                        TDSDate = request.TDSDate,
                        TDSAmount = request.TDSAmount,
                        TransactionNo = request.TransactionNo,
                        TDSFile = Path.GetFileName(response),
                        IsActive = true,
                        CreatedBy = "System",
                        CreatedAt = DateTime.Now
                    };

                    // Add the TDS entity to the context
                    await _dbcontext.tdss.AddAsync(tds, cancellationToken);

                    // Try saving the changes to the database
                    await _dbcontext.SaveChangesAsync(cancellationToken);
                  
                    response = "File Uploaded Successfully";
                }
            }
            catch (DbUpdateException dbEx)
            {
                Log.Error(dbEx, "Database update failed.");
                if (dbEx.InnerException != null)
                {
                    Log.Error(dbEx.InnerException, "Inner Exception: {Message}", dbEx.InnerException.Message);
                }
                response = "Database update failed. See logs for more details.";
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, "Error occurred in UploadTDS.");
                response = Ex.Message;
            }
            return response;
        }
        //public async Task<IEnumerable<Tds>> GetTDS(int BookingId, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        return await _dbcontext.tdss
        //            .Where(t => t.BookingID == BookingId)
        //            .ToListAsync(cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exception as needed
        //        throw;
        //    }
        //}
    }
}
