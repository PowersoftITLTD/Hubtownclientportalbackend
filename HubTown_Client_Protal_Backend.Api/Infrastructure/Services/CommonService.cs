using System.Security.Cryptography;

namespace HubTown_Client_Protal_Backend.Api.Infrastructure.Services
{
    public class CommonService : ICommonService
    {
        public async Task<string> GenerateOtp(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("Length must be at least 1.");
            }

            // Create a buffer to hold the random bytes
            byte[] randomBytes = new byte[length];

            // Fill the buffer with cryptographically strong random bytes
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            // Convert the random bytes to a positive integer
            int otpNumber = BitConverter.ToInt32(randomBytes, 0) & 0x7FFFFFFF;

            // Format the OTP to the desired length with leading zeros if needed
            return (otpNumber % (int)Math.Pow(10, length)).ToString("D" + length);
        }
    }
}
