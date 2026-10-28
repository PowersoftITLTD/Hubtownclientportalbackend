using Azure.Core;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using Serilog;
using System.Reflection.Metadata;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Services
{
    public class Document : IDocument
    {
        private readonly AppDbContext _context;
        private readonly string _CommonFilePath = string.Empty;
        private readonly IConfiguration configuration;
        private readonly string consumer_key = string.Empty;
        private readonly string consumer_secret = string.Empty;
        private readonly string access_token = string.Empty;
        private readonly string token_secret = string.Empty;
        private readonly string _realm = string.Empty;
        public Document(IConfiguration _configuration)
        {
            var FilePath = _configuration.GetSection("FilePaths");
            _CommonFilePath = FilePath.GetValue<string>("CommonFilePath") ?? "";
            if (!string.IsNullOrEmpty(_CommonFilePath) && !Directory.Exists(_CommonFilePath))
            {
                Directory.CreateDirectory(_CommonFilePath);
            }

            consumer_key = _configuration["NetSuiteCredential:consumer_key"]!;
            consumer_secret = _configuration["NetSuiteCredential:consumer_secret"]!;
            access_token = _configuration["NetSuiteCredential:access_token"]!;
            token_secret = _configuration["NetSuiteCredential:token_secret"]!;
            _realm = _configuration["NetSuiteCredential:Realm"]!;
            //configuration= _configuration;
        }

        public async Task<string> UploadAnyDocuemnts(Guid UserID, IFormFile File, string CommonChildFileName, CancellationToken cancellationToken = default)
        {
            string Result = string.Empty;
            try
            {
                if (File != null && File.Length > 0)
                {
                    string FolderPath = Path.Combine(_CommonFilePath, CommonChildFileName);
                    if (!Directory.Exists(FolderPath))
                    {
                        Directory.CreateDirectory(FolderPath);
                    }

                    string FilePath = Path.Combine(FolderPath, UserID + Path.GetExtension(File.FileName));
                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        await File.CopyToAsync(stream);
                        Result = FilePath;
                    }
                }
                else
                {
                    Result = "File is Empty";
                }
            }
            catch (Exception Ex)
            {
                Result = Ex.Message;
            }
            return Result;
        }

        // Thi Method Add by Itemad Hyder 28-10-2026
        public async Task<(MemoryStream, string, string)> DownloadDocument(string fileName, string CommonChildFileName, CancellationToken cancellationToken = default)
        {
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                // NetSuite OAuth credentials
                string consumerKey = consumer_key;
                string consumerSecret = consumer_secret;
                string accessToken = access_token;
                string tokenSecret = token_secret;
                string realm = _realm;
                Uri fileUri = null;
                // Accept either the complete RESTlet URL or a file ID.
                if (Uri.TryCreate(fileName, UriKind.Absolute, out Uri suppliedUri)
                    && (suppliedUri.Scheme == Uri.UriSchemeHttp ||
                        suppliedUri.Scheme == Uri.UriSchemeHttps))
                {
                    fileUri = suppliedUri;
                }
                else if (long.TryParse(fileName, out long fileId) && fileId > 0)
                {
                    fileUri = new Uri("https://7101051.suitetalk.api.netsuite.com" +
                                     "/services/rest/document/v1/file/" +
                                       Uri.EscapeDataString(fileId.ToString()) +
                                       "/content");
                }

                // Case 1: Download PDF from NetSuite REST API
                if (fileUri != null)
                {
                    var authenticator = OAuth1Authenticator.ForAccessToken(
                        consumerKey,
                        consumerSecret,
                        accessToken,
                        tokenSecret,
                        OAuthSignatureMethod.HmacSha256);

                    authenticator.Realm = realm;

                    var options = new RestClientOptions(
                        fileUri.GetLeftPart(UriPartial.Authority))
                    {
                        Authenticator = authenticator,
                        ThrowOnAnyError = false
                    };

                    using (var client = new RestClient(options))
                    {
                        var request = new RestRequest(
                            fileUri.PathAndQuery,
                            Method.Get);

                        request.AddHeader("Accept", "application/pdf");

                        RestResponse response = await client.ExecuteAsync(
                            request,
                            cancellationToken);

                        if (!response.IsSuccessful)
                        {
                            throw new Exception(
                                "NetSuite API failed. HTTP Status: " +
                                (int)response.StatusCode +
                                ", Response: " + response.Content);
                        }

                        // Read the actual PDF bytes returned by NetSuite
                        byte[] fileBytes = response.RawBytes;

                        if (fileBytes == null || fileBytes.Length == 0)
                        {
                            throw new Exception(
                                "NetSuite returned an empty file.");
                        }

                        // Validate the PDF file signature: %PDF-
                        if (fileBytes.Length < 5 ||
                            fileBytes[0] != 0x25 ||
                            fileBytes[1] != 0x50 ||
                            fileBytes[2] != 0x44 ||
                            fileBytes[3] != 0x46 ||
                            fileBytes[4] != 0x2D)
                        {
                            string responsePreview = response.Content ?? "";

                            if (responsePreview.Length > 500)
                            {
                                responsePreview =
                                    responsePreview.Substring(0, 500);
                            }

                            throw new Exception(
                                "NetSuite response is not a PDF. Content-Type: " +
                                response.ContentType +
                                ". Response: " + responsePreview);
                        }

                        await memoryStream.WriteAsync(
                            fileBytes,
                            0,
                            fileBytes.Length,
                            cancellationToken);
                    }

                    memoryStream.Position = 0;

                    return (
                        memoryStream,
                        "Hubtown" +"_" + fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf",
                        "application/pdf"
                    );
                }

                // Case 2: Download a local file
                string folderPath = Path.Combine(
                    _CommonFilePath,
                    CommonChildFileName);

                string filePath = Path.Combine(folderPath, fileName);

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(
                        "File not found: " + filePath);
                }

                using (var fileStream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read))
                {
                    await fileStream.CopyToAsync(
                        memoryStream,
                        81920,
                        cancellationToken);
                }

                memoryStream.Position = 0;

                return (
                    memoryStream,
                    Path.GetFileName(filePath),
                    GetContentType_PS(filePath)
                );
            }
            catch (Exception ex)
            {
                memoryStream.Dispose();

                throw new Exception(
                    "Error occurred while downloading the file: " +
                    ex.Message,
                    ex);
            }
        }


        private string GetContentType_PS(string path)
        {
            var types = new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase)
                {
                    { ".txt", "text/plain" },
                    { ".pdf", "application/pdf" },
                    { ".doc", "application/msword" },
                    { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                    { ".xls", "application/vnd.ms-excel" },
                    { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                    { ".jpg", "image/jpeg" },
                    { ".jpeg", "image/jpeg" },
                    { ".png", "image/png" }
                };

            string extension = Path.GetExtension(path);

            // For URLs, Path.GetExtension() sees media.nl.
            // Check the _xt query parameter for the real extension.
            if (Uri.TryCreate(path, UriKind.Absolute, out Uri uri) &&
                (uri.Scheme == Uri.UriSchemeHttp ||
                 uri.Scheme == Uri.UriSchemeHttps))
            {
                foreach (string parameter in uri.Query
                    .TrimStart('?').Split('&'))
                {
                    string[] parts = parameter.Split(new char[] { '=' }, 2);

                    if (parts.Length == 2 &&
                        Uri.UnescapeDataString(parts[0])
                            .Equals("_xt", StringComparison.OrdinalIgnoreCase))
                    {
                        extension = Uri.UnescapeDataString(parts[1]);
                        break;
                    }
                }
            }

            extension = extension.Trim().Trim('"');

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            return types.TryGetValue(extension, out string contentType)
                ? contentType
                : "application/octet-stream";
        }

        public async Task<(MemoryStream, string, string)> DownloadDocument_Old(string fileName, string CommonChildFileName, CancellationToken cancellationToken = default)
        {
            try
            {
                
                MemoryStream memoryStream = new MemoryStream();
                string contentType;
                string finalFileName;

                if (fileName.StartsWith("http://") || fileName.StartsWith("https://"))
                {
                    // If fileName is a URL, download the file from the URL
                    using (HttpClient client = new HttpClient())
                    {
                        var fileBytes = await client.GetByteArrayAsync(fileName);
                        memoryStream = new MemoryStream(fileBytes);
                    }

                    contentType = GetContentType(fileName);
                    finalFileName = Path.GetFileName(new Uri(fileName).LocalPath);
                }
                else
                {
                    // If fileName is a local path, find it in the file system
                    string folderPath = Path.Combine(_CommonFilePath, CommonChildFileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    if (!System.IO.File.Exists(filePath))
                    {
                        throw new FileNotFoundException("File not found.");
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        await fileStream.CopyToAsync(memoryStream);
                    }

                    contentType = GetContentType(filePath);
                    finalFileName = Path.GetFileName(filePath);
                }

                memoryStream.Position = 0;
                return (memoryStream, finalFileName, contentType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while downloading the file: {ex.Message}");
            }
        }


        // Helper method to get content type based on file extension
        private string GetContentType(string path)
        {
            var types = new Dictionary<string, string>
            {
                { ".txt", "text/plain" },
                { ".pdf", "application/pdf" },
                { ".doc", "application/msword" },
                { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { ".xls", "application/vnd.ms-excel" },
                { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".png", "image/png" }
            };

            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types.ContainsKey(ext) ? types[ext] : "application/octet-stream";
        }
        public async Task<bool> DeleteDocument(string fileName, string CommonChildFileName, CancellationToken cancellationToken = default)
        {
            string filename = "";
            try
            {

                string folderPath = Path.Combine(_CommonFilePath, CommonChildFileName);
                string filePath = Path.Combine(folderPath, fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }
                else return false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error occurred while deleting the file: {filename}");
                return false;
            }
        }



    }
}

