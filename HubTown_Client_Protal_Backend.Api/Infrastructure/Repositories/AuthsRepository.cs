using HubTown_Client_Protal_Backend.Api.Application.DTOs;
using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Domain.Entity;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories
{
    public class AuthsRepository(AppDbContext _DbContext, IConfiguration _configuration, ICommonService _commonService, ISendService _sendService) : IAuthsRepository
    {
        //CommonService _CommonService = new CommonService();

        public async Task<string> GetJWTToken(Guid userId, CancellationToken cancellationToken = default)
        {
            try
            {
                if (userId != Guid.Empty)
                {
                    // Retrieve JWT settings from configuration
                    var jwtSettings = _configuration.GetSection("JwtSettings");
                    var secretKey = jwtSettings.GetValue<string>("SecretKey");
                    var issuer = jwtSettings.GetValue<string>("Issuer");
                    var audience = jwtSettings.GetValue<string>("Audience");

                    // Create security key and signing credentials
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    // Define JWT claims
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,Convert.ToString(userId)),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    // Create the JWT token
                    var token = new JwtSecurityToken(
                        issuer: issuer,
                        audience: audience,
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(24),
                        signingCredentials: credentials);

                    return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return "UserID is empty";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //public async Task<GetOTPResponse> GetOTP(GetOTPRequest request, CancellationToken cancellationToken = default)
        //{
        //    GetOTPResponse response = new GetOTPResponse();
        //    try
        //    {
        //        string OTP = string.Empty;
        //        User? user = new User();

        //        var Auths = _configuration.GetSection("Auths");
        //        int OTPLength = Auths.GetValue<int>("OTPLength");
        //        int OTPExpireIn = Auths.GetValue<int>("OTPExpireIn");

        //        // Check for valid EmailID and MobileNumber, and fetch the user accordingly
        //        if (!string.IsNullOrEmpty(request.EmailID))
        //        {
        //            user = await CheckUser(request.EmailID);
        //        }
        //        else if (!string.IsNullOrEmpty(request.MobileNumber))
        //        {
        //            user = await CheckUser(request.MobileNumber);
        //        }

        //        // If user is valid and UserID is not empty, proceed
        //        if (user != null && user.UserID != Guid.Empty)
        //        {
        //            response.UserID = user.UserID;

        //            // Generate OTP if the user exists and UserID is valid
        //            OTP = await _commonService.GenerateOtp(OTPLength);

        //            // Send OTP via SendGrid or SMS
        //            response.OTPSend = await OTPSendStatus(OTP,
        //                !string.IsNullOrEmpty(request.EmailID) ? request.EmailID : request.MobileNumber,
        //                !string.IsNullOrEmpty(request.EmailID) ? "EMAIL" : "SMS");

        //            if (response.OTPSend == true)
        //            {
        //                DateTime nowUtc = DateTime.UtcNow.AddSeconds(OTPExpireIn);

        //                TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Kolkata");
        //                DateTime nowIST = TimeZoneInfo.ConvertTimeFromUtc(nowUtc, istTimeZone);

        //                // Update user OTP details
        //                user.CurrentOTP = OTP;
        //                user.OTPExpiry = nowIST;
        //                user.ModifiedAt = DateTime.Now;
        //                _DbContext.Update(user);

        //                // Fetch and update userLogin if exists, else create new entry
        //                var userLogin = await _DbContext.userlogins
        //                    .Where(x => x.UserID == response.UserID && x.IsActive && !x.IsUsed)
        //                    .OrderByDescending(x => x.CreatedAt)
        //                    .FirstOrDefaultAsync(cancellationToken);

        //                if (userLogin != null)
        //                {
        //                    userLogin.OTP = OTP;
        //                    userLogin.ExpiresAt = user.OTPExpiry;
        //                    userLogin.ModifiedBy = "";
        //                    userLogin.ModifiedAt = DateTime.Now;
        //                    _DbContext.Update(userLogin);
        //                }
        //                else
        //                {
        //                    userLogin = new UserLogin
        //                    {
        //                        UserID = response.UserID,
        //                        OTP = OTP,
        //                        ExpiresAt = user.OTPExpiry,
        //                        IsUsed = false,
        //                        IsActive = true,
        //                        CreatedBy = "",
        //                        CreatedAt = DateTime.Now
        //                    };
        //                    _DbContext.userlogins.Add(userLogin);
        //                }

        //                // Save all changes
        //                await _DbContext.SaveChangesAsync();
        //            }
        //        }
        //        else
        //        {
        //            response.OTPSend = false;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        Console.WriteLine($"Error: {Ex.Message}");
        //        response.OTPSend = false;
        //    }

        //    return response;
        //}


        public async Task<GetOTPResponse> GetOTP(GetOTPRequest request, CancellationToken cancellationToken = default)
        {
            GetOTPResponse response = new GetOTPResponse();
            string OTP = string.Empty;
            User? user = null;
            bool smsSuccess = false;
            string smsApiResponse = string.Empty;

            try
            {
                Log.Information($"Request.MobileNumber = '{request.MobileNumber}'");

                var Auths = _configuration.GetSection("Auths");
                int OTPLength = Auths.GetValue<int>("OTPLength");
                int OTPExpireIn = Auths.GetValue<int>("OTPExpireIn");

                var smsApiEndpoint = _configuration.GetValue<string>("SmsService:ApiEndpoint");

                // Fetch user
                user = await CheckUser(request.MobileNumber);
                Log.Information($"User fetched: {user?.UserID}");

                if (user != null && user.UserID != Guid.Empty)
                {
                    response.UserID = user.UserID;
                    OTP = await _commonService.GenerateOtp(OTPLength);

                    response.OTPSend = await OTPSendStatus(OTP,
                        !string.IsNullOrEmpty(request.EmailID) ? request.EmailID : request.MobileNumber,
                        !string.IsNullOrEmpty(request.EmailID) ? "EMAIL" : "SMS");

                    if (response.OTPSend)
                    {
                        DateTime expiryTime = DateTime.Now.AddMinutes(OTPExpireIn);

                        // Update user OTP
                        user.CurrentOTP = OTP;
                        user.OTPExpiry = expiryTime;
                        user.ModifiedAt = DateTime.Now;
                        _DbContext.Update(user);

                        var userLogin = await _DbContext.userlogins
                            .Where(x => x.UserID == response.UserID && x.IsActive && !x.IsUsed)
                            .OrderByDescending(x => x.CreatedAt)
                            .FirstOrDefaultAsync(cancellationToken);

                        if (userLogin != null)
                        {
                            userLogin.OTP = OTP;
                            userLogin.ExpiresAt = expiryTime;
                            userLogin.ModifiedAt = DateTime.Now;
                            _DbContext.Update(userLogin);
                        }
                        else
                        {
                            _DbContext.userlogins.Add(new UserLogin
                            {
                                UserID = user.UserID,
                                OTP = OTP,
                                ExpiresAt = expiryTime,
                                IsUsed = false,
                                IsActive = true,
                                CreatedBy = "",
                                CreatedAt = DateTime.Now,
                                UserName = user.Name // Username inserted
                            });
                        }

                        await _DbContext.SaveChangesAsync();

                        // Send OTP via SMS API
                         smsSuccess = await SendOtpToSmsService(user.Mobile, OTP, smsApiEndpoint); 
                      // smsSuccess = true;
                        response.OTPSend = smsSuccess;
                        response.Message = smsSuccess ? "OTP Sent Successfully" : "OTP Sending Failed";
                        smsApiResponse = smsSuccess ? "Success" : "Failed";
                    }
                    else
                    {
                        smsApiResponse = "Send logic failed before SMS service";
                    }
                }
                else
                {
                    response.OTPSend = false;
                    smsApiResponse = "User not found or invalid";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while sending OTP");
                response.OTPSend = false;
                smsApiResponse = $"Exception: {ex.Message}";
            }

            // Save audit log

           
                var auditLog = new OtpAuditLog
                {
                    UserID = user?.UserID,
                    MobileNumber = request?.MobileNumber, // added ? to avoid null reference
                    EmailID = request?.EmailID,
                    Channel = !string.IsNullOrEmpty(request?.EmailID) ? "EMAIL" : "SMS",
                    OTP = OTP,
                    OTPGeneratedAt = response?.OTPSend == true ? DateTime.Now : null,
                    OTPExpiryAt = response?.OTPSend == true ? DateTime.Now.AddMinutes(5) : null,
                    OTPSendStatus = response?.OTPSend ?? false, // default false if null
                    SmsApiResponse = smsApiResponse,
                    CreatedAt = DateTime.Now
                };

                _DbContext.OtpAuditLogs.Add(auditLog);
                await _DbContext.SaveChangesAsync();
            


            return response;
        }

        public async Task<VerifyOTPResponse> VerifyOTP(VerifyOTPRequest request, CancellationToken cancellationToken = default)
        {
            VerifyOTPResponse response = new VerifyOTPResponse();

            try
            {
                // Validate UserID
                if (request.UserID == Guid.Empty)
                {
                    throw new ArgumentException("User ID cannot be empty.");
                }
                User? user = null; // Initialize user to null, since it's only needed if found
                List<Project> projects = new List<Project>();
                List<Booking> bookings = new List<Booking>();
                List<int> projectIds = new List<int>();

                using (var command = _DbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "ValidateAndFetchUserDetailsAndProjects";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@UserID", request.UserID));
                    command.Parameters.Add(new SqlParameter("@IsAdmin", request.IsAdmin));
                    command.Parameters.Add(new SqlParameter("@EnteredOTP", request.EnteredOTP));

                    await _DbContext.Database.OpenConnectionAsync(cancellationToken);

                    using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        // Fetch Error Message
                        var columnExists = Enumerable.Range(0, reader.FieldCount).Any(i => reader.GetName(i) == "ErrorMessage");

                        if (columnExists && await reader.ReadAsync(cancellationToken))
                        {
                            var errorMessage = reader.GetString(reader.GetOrdinal("ErrorMessage"));
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                response.Message = errorMessage;
                                return response; // Return early if there's an error message
                            }
                        }

                        // Fetch User Details (First Result Set)
                        if (reader.HasRows && await reader.ReadAsync(cancellationToken))
                        {
                            user = new User
                            {
                                UserID = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Mobile = reader.GetString(3)
                            };

                            response.Token = await GetJWTToken(request.UserID, cancellationToken);
                        }

                        // Fetch Projects (Second Result Set)
                        if (await reader.NextResultAsync(cancellationToken))
                        {
                            while (await reader.ReadAsync(cancellationToken))
                            {
                                projectIds.Add(reader.GetInt32(0));

                                projects.Add(new Project
                                {
                                    ProjectId = reader.GetInt32(0),
                                    ProjectName = reader.GetString(1),
                                    Status = reader.GetString(2),
                                    ProjectLogoUrl = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    Rerano = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    ReraDocument = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                    ReraLink = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    Address = reader.GetString(7),
                                    Facebooklink = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                    Instagramlink = reader.IsDBNull(9) ? "" : reader.GetString(9),
                                    ProjectImage = reader.IsDBNull(10) ? "" : reader.GetString(10),
                                    websiteLink = reader.IsDBNull(11) ? "" : reader.GetString(11),
                                    booking = new Booking() // Initialize empty booking
                                });
                            }
                        }

                        // Fetch Bookings (Third Result Set)
                        if (await reader.NextResultAsync(cancellationToken))
                        {
                            while (await reader.ReadAsync(cancellationToken))
                            {
                                bookings.Add(new Booking
                                {
                                    ProjectId = reader.GetInt32(0),
                                    BookingID = reader.GetInt32(1),
                                    OCNo = reader.GetString(2),
                                    OCDate = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                                    Status = reader.GetString(4),
                                    Building = reader.GetString(5),
                                    Unit = reader.GetString(6),
                                    Area = reader.GetString(7),
                                    Floor = reader.GetString(8),
                                    CarPark = reader.IsDBNull(9) ? null : reader.GetInt32(9),
                                    UnitType = reader.GetString(10),
                                    OutstandingWithinDueAmount = reader.IsDBNull(11) ? null : reader.GetDecimal(11),
                                    OutstandingOverdueAmount = reader.IsDBNull(12) ? null : reader.GetDecimal(12),
                                    TDSOutstanding = reader.IsDBNull(13) ? null : reader.GetDecimal(13),
                                    RegistrationNumber = reader.GetString(14),
                                    RegistrationActualDate = reader.IsDBNull(15) ? null : reader.GetDateTime(15),
                                    RegistrationTentativeDate = reader.IsDBNull(16) ? null : reader.GetDateTime(16),
                                    FitoutDate = reader.IsDBNull(17) ? null : reader.GetDateTime(17),
                                    PossessionFinalDate = reader.IsDBNull(18) ? null : reader.GetDateTime(18),
                                    RmName = reader.GetString(19),
                                    RmEmail = reader.GetString(20),
                                    RmContact = reader.GetString(21),
                                    RegistrationDocumentUrl = reader.IsDBNull(22) ? "" : reader.GetString(22),
                                    PossessionDocumentUrl = reader.IsDBNull(23) ? "" : reader.GetString(23)
                                });
                            }
                        }
                    }

                    var projectImages = await _DbContext.ProjectImages
                                        .Where(pi => projectIds.Contains(pi.ProjectID) && pi.IsActive)
                                        .ToListAsync();

                    var distinctProjects = projects
                                        .GroupBy(p => new { p.ProjectId })  // Group by projectId and bookingID
                                        .Select(g => g.First()) // Take only the first occurrence
                                        .ToList();


                    foreach (var project in distinctProjects)
                    {
                        project.ListProjectImages = projectImages.Where(pi => pi.ProjectID == project.ProjectId).ToList();
                    }

                    // Assign Bookings to Projects
                    //List<Project> NewProject = new List<Project>();
                    //foreach (var project in projects)
                    //{
                    //    foreach (var booking in bookings)
                    //    {
                    //        if (booking.ProjectId == project.ProjectId)
                    //        {
                    //            project.booking = booking;
                    //            NewProject.Add(project);
                    //            break;
                    //        }
                    //    }
                    //}

                    var NewProject = (from project in distinctProjects
                                      join booking in bookings
                                      on project.ProjectId equals booking.ProjectId
                                      select new Project
                                      {
                                          ProjectId = project.ProjectId,
                                          ProjectName = project.ProjectName,
                                          Status = project.Status,
                                          ProjectLogoUrl = project.ProjectLogoUrl,
                                          Rerano = project.Rerano,
                                          ReraDocument = project.ReraDocument,
                                          ReraLink = project.ReraLink,
                                          Address = project.Address,
                                          Facebooklink = project.Facebooklink,
                                          Instagramlink = project.Instagramlink,
                                          ProjectImage = project.ProjectImage,
                                          ListProjectImages = project.ListProjectImages,
                                          websiteLink = project.websiteLink,
                                          booking = booking
                                      }).ToList();



                    response.Users = user;
                    response.Projects = NewProject;

                    // Perform Validation for users/projects
                    var missingFields = new List<string>();

                    if (response.Users == null)
                        missingFields.Add("User details are missing.");
                    if (response.Projects == null || !response.Projects.Any())
                        missingFields.Add("Projects are missing.");
                    if (!response.Projects.Any(p => p.booking != null))
                        missingFields.Add("Booking details are missing.");

                    if (missingFields.Any())
                    {
                        response.Users = null; // Remove user details
                        response.Token = null; // Remove token

                        throw new KeyNotFoundException("User Detail is missing, please contact admin");
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            finally
            {
                await _DbContext.Database.CloseConnectionAsync();
            }

            return response;
        }

        private async Task<bool> SendOtpToSmsService(string phoneNumber, string otp, string apiEndpoint)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var payload = new
                    {
                        phoneNumber = phoneNumber,
                        otp = otp
                    };

                    var jsonPayload = JsonSerializer.Serialize(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(apiEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("OTP successfully sent via SMS service.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to send OTP via SMS service. Response: {await response.Content.ReadAsStringAsync()}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending OTP via SMS service: {ex.Message}");
                return false;
            }
        }

        async Task<User?> CheckUser(string Value)
        {
            User? User = await _DbContext.users.Where(u => u.Email == Value || u.Mobile == Value).FirstOrDefaultAsync();
            //User? User = await (from u in _DbContext.users
            //                    where (u.Email == Value || u.Mobile == Value)
            //select new User
            //{
            //    UserID = u.UserID,
            //    Name = u.Name,
            //    Email = u.Email,
            //    Mobile = u.Mobile,
            //    CurrentOTP = u.CurrentOTP,
            //    OTPExpiry = u.OTPExpiry
            //}).FirstOrDefaultAsync();
            return User;
        }
        private async Task<bool> OTPSendStatus(string OTP, string? value, string flag)
        {
            bool status = false;
            try
            {
                if (flag == "EMAIL")
                {
                    // Use SendGridService to send OTP via email
                    string subject = "Your OTP Code";
                    string body = $"Your OTP code is: {OTP}";
                    status = await _sendService.SendEmailAsync(value, subject, body);
                }
                else if (flag == "SMS")
                {
                    // Logic to send OTP via SMS (e.g., Twilio or other SMS provider)
                     status = await _sendService.SendSmsAsync(value, $"Your OTP code is: {OTP}");
                   // status = true;  // Placeholder, replace with actual SMS sending logic.
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Error sending OTP: {Ex.Message}");
                status = false;
            }
            return status;
        }

        public async Task<object> VerifyAdminCredentialsAsync(VerifyAdminRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.Password) ||
                (string.IsNullOrWhiteSpace(request.EmailID) && string.IsNullOrWhiteSpace(request.MobileNumber)))
            {
                throw new ArgumentException("Email or Mobile Number and Password are required.");
            }

            var user = await _DbContext.users
                .Where(u => u.Email == request.EmailID || u.Mobile == request.MobileNumber)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email/mobile number or password.");
            }
            // bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            // if (!isPasswordValid)
            // {
            //     throw new UnauthorizedAccessException("Invalid email/mobile number or password.");
            // }

            // Normal password check (for now)
            if (user.Password != request.Password)
            {
                throw new UnauthorizedAccessException("Invalid email/mobile number or password.");
            }

            // Check if the user is an admin
            if (!user.IsAdmin)
            {
                throw new UnauthorizedAccessException("Access denied. Admin privileges required.");
            }

            return new { IsAdmin = true };
        }

        public async Task<List<object>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _DbContext.users
                .Where(u => !u.IsAdmin)
                .Select(u => (object)new
                {
                    UserId = u.UserID,
                    UserName = u.Name,
                    mobile = u.Mobile
                })
                .ToListAsync(cancellationToken);

            return users;
        }



    }
}
