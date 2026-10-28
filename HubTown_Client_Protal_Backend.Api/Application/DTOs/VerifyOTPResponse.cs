using HubTown_Client_Protal_Backend.Api.Domain.Entity;

namespace HubTown_Client_Protal_Backend.Api.Application.DTOs
{
    public class VerifyOTPResponse
    {
        public string? Message { get; set; }
        public User? Users { get; set; }
        public List<Project>? Projects { get; set; }
        public string? Token { get; set; }
     public bool IsValid(out string validationMessage)
        {
            List<string> missingFields = new List<string>();

            if (string.IsNullOrWhiteSpace(Message))
                missingFields.Add(nameof(Message));

            if (Users == null)
                missingFields.Add(nameof(Users));

            if (Projects == null || Projects.Count == 0)
                missingFields.Add(nameof(Projects));

            if (string.IsNullOrWhiteSpace(Token))
                missingFields.Add(nameof(Token));

            if (missingFields.Count > 0)
            {
                validationMessage = $"Missing or invalid fields: {string.Join(", ", missingFields)}.";
                return false;
            }

            validationMessage = "All fields are valid.";
            return true;
        }
    }
}