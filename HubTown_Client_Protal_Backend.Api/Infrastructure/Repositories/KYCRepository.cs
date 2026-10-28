using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using Serilog;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories
{
    public class KYCRepository(AppDbContext _dbcontext, IDocument _document) : IKYCRepository
    {
        public async Task<IEnumerable<KycUpload>> GetKYCDetails(int BookingID, CancellationToken cancellationToken = default)
        {
            try
            {
                return await (_dbcontext.kycuploads.Where(x => x.BookingID == BookingID && x.IsActive == true).ToListAsync(cancellationToken));
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public async Task<string> UploadKYC(UploadKYCFileRequest request, CancellationToken cancellationToken = default)
        {
            string response = string.Empty;
            try
            {
                response = await _document.UploadAnyDocuemnts(request.UserID, request.File, "Kyc", cancellationToken);
                if (!string.IsNullOrEmpty(response))
                {
                    KycUpload kycUpload = new KycUpload();
                    kycUpload.BookingID = request.BookingID;
                    kycUpload.OwnerName = request.OwnerName;
                    kycUpload.DocumentName = request.DocumentName;
                    kycUpload.DocumentFile = Path.GetFileName(response);
                    kycUpload.IsActive = true;
                    kycUpload.CreatedBy = request.UserID.ToString();
                    kycUpload.CreatedAt = DateTime.Now;

                    await _dbcontext.kycuploads.AddAsync(kycUpload, cancellationToken);
                    await _dbcontext.SaveChangesAsync(cancellationToken);

                    response = "File Uploaded Successfully";
                }
            }
            catch (Exception Ex)
            {
                response = Ex.Message;
            }
            return response;
        }
        public async Task<string> DeleteKYC(Guid kycid, CancellationToken cancellationToken = default)
        {
            string filename = "";
            try
            {

                var document = await _dbcontext.kycuploads.Where(d => d.KycId == kycid && d.IsActive == true).FirstOrDefaultAsync();

                if (document != null)
                {
                    bool delete = await _document.DeleteDocument(document.DocumentFile, "Kyc");
                    if (delete)
                    {
                        filename = document.DocumentName;
                        document.IsActive = false;
                        document.ModifiedAt = DateTime.Now;
                        _dbcontext.kycuploads.Update(document);

                        await _dbcontext.SaveChangesAsync();
                        return "File Deleted Successfully";
                    }
                    else
                    {
                        return "File Not Exists";
                    }
                }
                else
                {
                    return "File Not Found";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error occurred while deleting the file: {filename}");
                return "File Not Deleted";
            }
        }

    }
}
