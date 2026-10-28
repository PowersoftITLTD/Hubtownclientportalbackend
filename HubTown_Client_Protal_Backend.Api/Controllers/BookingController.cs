using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HubTown_Client_Protal_Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Customer/[controller]/[action]")]
    public class BookingController(IBookingService _BookingService, IDocument _document) : ApiController
    {
        //[HttpGet]
        //public async Task<IActionResult> GetPropertyList()
        //{
        //    try
        //    {
        //        return Ok(await _BookingService.GetPropertyList());
        //    }
        //    catch (Exception Ex)
        //    {
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetPropertyDetails()
        //{
        //    try
        //    {
        //        return Ok(_BookingService.GetPropertyDetails());
        //    }
        //    catch (Exception Ex)
        //    {
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetMilestoneDetails()
        //{
        //    try
        //    {
        //        return Ok(await _BookingService.GetMilestoneDetails());
        //    }
        //    catch (Exception Ex)
        //    {
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetDemandDetails()
        //{
        //    try
        //    {
        //        return Ok(await _BookingService.GetDemandDetails());
        //    }
        //    catch (Exception Ex)
        //    {
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetReceiptsDetails()
        //{
        //    try
        //    {
        //        return Ok(await _BookingService.GetReceiptsDetails());
        //    }
        //    catch (Exception Ex)
        //    {
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetHomeLoanNOCDetails()
        //{
        //    try
        //    {
        //        return Ok(await _BookingService.GetHomeLoanNOCDetails());
        //    }
        //    catch (Exception Ex)
        //    {
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //}
        //Added By Shubham
        [HttpGet]
        public async Task<IActionResult> GetDemandBreakup([FromQuery] int? BookingID)
        {
            try
            {
                return Ok(await _BookingService.GetDemandBreakup(BookingID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetDemandBreakup", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAccountSummary([FromQuery] int? BookingID)
        {
            try
            {
                return Ok(await _BookingService.GetAccountSummary(BookingID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetAccountSummary", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBankPayableAccounts([FromQuery] int? BookingID)
        {
            try
            {
                return Ok(await _BookingService.GetBankPayableAccounts(BookingID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetBankPayableAccounts", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetDemandLetters([FromQuery] int? BookingID)
        {
            try
            {
                return Ok(await _BookingService.GetDemandLetters(BookingID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetDemandLetters", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        //Ended By Shubham
        [HttpGet]
        public async Task<IActionResult> GetBooking([FromQuery] Guid? UserID, [FromQuery] int? ProjectID)
        {
            try
            {
                return Ok(await _BookingService.GetBooking(UserID, ProjectID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetBooking", UserID, ProjectID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCoOwner([FromQuery] Guid? UserID, [FromQuery] int? BookingID)
        {
            try
            {
                return Ok(await _BookingService.GetCoOwner(UserID, BookingID));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetCoOwner", UserID, BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetReceipts([FromQuery] int BookingID)
        {
            try
            {
                var receiptsDetails = await _BookingService.GetReceipts(BookingID);
                if (receiptsDetails != null)
                {
                    return Ok(receiptsDetails);
                }
                return NotFound("Receipts details not found.");
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetReceipts", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetHomeLoanNOC([FromQuery] int BookingID)
        {
            try
            {
                var homeLoanNocDetails = await _BookingService.GetHomeLoanNOC(BookingID);
                if (homeLoanNocDetails != null)
                {
                    return Ok(homeLoanNocDetails);
                }
                return NotFound("Home Loan NOC details not found.");
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetHomeLoanNOC", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMilestones([FromQuery] int BookingID)
        {
            try
            {
                var milestoneDetails = await _BookingService.GetMilestones(BookingID);
                if (milestoneDetails != null)
                {
                    return Ok(milestoneDetails);
                }
                return NotFound("Milestone details not found.");
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetMilestones", BookingID);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        [HttpGet]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            try
            {
                string commonChildFileName = "File";

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
        [HttpGet]
        public async Task<IActionResult> GetUpcomingProject()
        {
            try
            {
                return Ok(await _BookingService.GetUpcomingProject());
            }
            catch (Exception Ex)
            {

                Log.Error(Ex, Ex.Message, "GetUpcomingProject");
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectUpdates(int projectid)
        {
            try
            {
                return Ok(await _BookingService.GetProjectUpdates(projectid));
            }
            catch (Exception Ex)
            {

                Log.Error(Ex, Ex.Message, "GetProjectUpdates");
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
