using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HubTown_Client_Protal_Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Customer/[controller]/[action]")]
    public class KYCController(IKYCService _KYCMaster, IDocument _document) : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetKYCDetails([FromQuery] int BookingID)
        {
            try
            {
                return Ok(await _KYCMaster.GetKYCDetails(BookingID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetKYCDetails");
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadKYCFile(UploadKYCFileRequest request)
        {
            try
            {
                return Ok(await _KYCMaster.UploadKYC(request));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "UploadKYC");
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadKYCFile(string fileName)
        {
            try
            {
                string commonChildFileName = "Kyc";

                var (memoryStream, downloadedFileName, contentType) = await _document.DownloadDocument(fileName, commonChildFileName);

                return File(memoryStream, contentType, downloadedFileName);
            }
            catch (FileNotFoundException)
            {
                return NotFound("File not found.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while downloading the file.");
                return StatusCode(500, "Internal server error.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteKYCFile([FromQuery] Guid kycid)
        {
            try
            {
                string response = await _KYCMaster.DeleteKYC(kycid);
                return Ok(new { message = response });
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "DeleteKYCFile");
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

    }
}
