using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Application.Services;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.IO;

namespace HubTown_Client_Protal_Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Customer/[controller]/[action]")]
    public class TDSController(ITDSService _TDSMaster, IDocument _document) : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetTDSDetails([FromQuery] int BookingID)
        {
            try
            {
                return Ok(await _TDSMaster.GetTDSDetails(BookingID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetTDSDetails", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadTDSFile(UploadTDSFileRequest request)
        {
            try
            {
                return Ok(await _TDSMaster.UploadTDS(request));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "UploadTDS");
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }



        [HttpGet]
        public async Task<IActionResult> DownloadTDSFile(string fileName)
        {
            try
            {               
                string commonChildFileName = "TDS"; 
              
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




        //[HttpGet]
        //public async Task<IActionResult> GetTDS([FromQuery] int BookingID)
        //{
        //    try
        //    {
        //        var tdsDetails = await _TDSMaster.GetTDS(BookingID);
        //        if (tdsDetails != null)
        //        {
        //            return Ok(tdsDetails);
        //        }
        //        return NotFound("TDS details not found.");
        //    }
        //    catch (Exception Ex)
        //    {
        //        Log.Error(Ex, Ex.Message, "GetTDS", BookingID);
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //    finally
        //    {
        //        Log.CloseAndFlush();
        //    }
        //}
    }
}
