using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Application.Services;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HubTown_Client_Protal_Backend.Api.Controllers
{
    [Authorize]
    [Route("api/Customer/[controller]/[action]")]
    public class NotificationController(INotificationService _Notification) : ApiController
    {
        //[HttpGet]
        //public async Task<IActionResult> GetNotificationDetails()
        //{
        //    try
        //    {
        //        return Ok(await _Notification.GetNotificationDetails());
        //    }
        //    catch (Exception Ex)
        //    {
        //        Log.Error(Ex, Ex.Message, "GetNotificationDetails");
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //    finally
        //    {
        //        Log.CloseAndFlush();
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetUpcomingProjectsDetails()
        //{
        //    try
        //    {
        //        return Ok(await _Notification.GetUpcomingProjectsDetails());
        //    }
        //    catch (Exception Ex)
        //    {
        //        Log.Error(Ex, Ex.Message, "GetUpcomingProjectsDetails");
        //        return BadRequest(new { error = Ex.Message });
        //    }
        //    finally
        //    {
        //        Log.CloseAndFlush();
        //    }
        //}
        [HttpGet("GetFAQ")]
        public async Task<IActionResult> GetFAQ(CancellationToken cancellationToken = default)
        {
            try
            {
                var faqs = await _Notification.GetFAQ(cancellationToken);
                return Ok(faqs); // Return FAQs as JSON
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching FAQs");
                return BadRequest(new { error = ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("{BookingID}")]
        public async Task<IActionResult> GetNotificationsByBookingID(int BookingID)
        {
            try
            {
                var notifications = await _Notification.GetNotificationsByBookingID(BookingID);
                //if (notifications == null || !notifications.Any())
                //{
                //    return NotFound(new { Success = false, Message = "No notifications found" });
                //}
                return Ok(notifications);
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GetNotificationsByBookingID");
                return BadRequest(new { Success = false, Message = "Request failed", Error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpPost("{NotificationID}")]
        public async Task<IActionResult> UpdateNotificationStatus(int NotificationID)
        {
            try
            {
                var result = await _Notification.UpdateNotificationStatus(NotificationID);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Notification not found" });
                }
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "UpdateNotificationStatus");
                return BadRequest(new { Success = false, Message = "Request failed", Error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
