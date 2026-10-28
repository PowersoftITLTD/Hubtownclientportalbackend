namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Services
{
    public interface IDocument
    {
        Task<string> UploadAnyDocuemnts(Guid UserID, IFormFile File, string CommonChildFileName, CancellationToken cancellationToken = default);

        Task<(MemoryStream, string, string)> DownloadDocument(string fileName, string commonChildFileName, CancellationToken cancellationToken = default);
       // Task<(MemoryStream, string, string)> DownloadDocument_PS(string fileName, string commonChildFileName, CancellationToken cancellationToken = default);
       // Task<(MemoryStream, string, string)> DownloadDocument_PSAuth(string fileName, string commonChildFileName, CancellationToken cancellationToken = default);

         Task<bool> DeleteDocument(string fileName, string commonChildFileName, CancellationToken cancellationToken = default);
    }
        //Task<IFormFile> UploadAnyDocuemnts(string FilePath, CancellationToken cancellationToken = default);
    }

