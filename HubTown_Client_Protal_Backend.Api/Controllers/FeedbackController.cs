using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HubTown_Client_Protal_Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class FeedbackController(IFeedbackService _feedbackService) : ApiController
    {
        [HttpGet("GetInformationList")]
        public async Task<IActionResult> GetInformationList()
        {
            try
            {
                return Ok(await _feedbackService.GetInformationList());
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetInformationList", "");
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpPost("SaveFeedback")]
        public async Task<IActionResult> SaveFeedback([FromBody] FeedbackRequest request)
        {
            try
            {
                return Ok(await _feedbackService.SaveFeedback(request));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "SaveFeedback", request);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [HttpPost("GetFeedback")]
        public async Task<IActionResult> GetFeedback([FromBody] GetFeedbackRequest request)
        {
            try
            {
                return Ok(await _feedbackService.GetFeedback(request));
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetFeedback", request);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
