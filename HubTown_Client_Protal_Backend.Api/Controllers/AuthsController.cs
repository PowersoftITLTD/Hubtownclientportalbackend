using Azure.Core;
using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HubTown_Client_Protal_Backend.Api.Controllers
{

    //[ApiController]
    [Route("api/Customer/[controller]/[action]")]
    public class AuthsController(IAuthsService _Auths) : ApiController
    {
        //private readonly IAuthsService _Auths;
        ////private readonly IConfiguration _configuration;

        //public AuthsController(IAuthsService Auths)
        //{
        //    _Auths = Auths;
        //}

        // Endpoint to generate JWT Token
        [HttpPost]
        public async Task<IActionResult> GenerateToken(Guid userId)
        {
            try
            {
                var token = await _Auths.GetJWTToken(userId);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(new { token });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GenerateToken", userId);
                return Unauthorized();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> GenerateOTP(GetOTPRequest request)
        {
            try
            {
                GetOTPResponse response = await _Auths.GetOTP(request);
                if (response.OTPSend == true)
                {
                    return Ok(response);
                }
                else
                {
                    response.Message = "User is Invalid.";
                   throw new Exception(response.Message);
                }
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "GenerateOTP", request);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> VerifyOTP(VerifyOTPRequest request)
        {
            try
            {
                VerifyOTPResponse response = await _Auths.VerifyOTP(request);
                if (response.Users != null && response.Projects != null)
                {
                    return Ok(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception Ex)
            {
                Log.Error(Ex, Ex.Message, "VerifyOTP", request);
                return BadRequest(new { error = Ex.Message });
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        [HttpPost("admin/login")]
        public async Task<ActionResult> AuthAdminLogin(VerifyAdminRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Password) ||
                    (string.IsNullOrEmpty(request.EmailID) && string.IsNullOrEmpty(request.MobileNumber)))
                {
                    return BadRequest(new { error = "Email or Mobile Number and Password are required." });
                }

                var authResponse = await _Auths.VerifyAdminCredentialsAsync(request);

                if (authResponse == null)
                {
                    return Unauthorized(new { error = "Invalid credentials or not an admin." });
                }

                return Ok(new
                {
                    message = "Admin login successful.",
                    isAdmin = true  // Include the `isAdmin` response
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message, "AuthAdminLogin", request);
                return StatusCode(500, new { error = "An error occurred during authentication." });
            }
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<object>>> GetUsers()
        {
            try
            {
                var users = await _Auths.GetUsersAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving users");
                return StatusCode(500, new { error = "An error occurred while retrieving users." });
            }
        }


    }
}
