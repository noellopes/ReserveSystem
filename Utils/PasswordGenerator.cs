using System.Security.Cryptography;
using System.Text;

namespace ReserveSystem.Utils
{
    public static class PasswordGenerator
    {
        private static readonly string[] SpecialChars = ["@", "#", "$", "%", "&", "*", "!", "?"];
        
        public static string GenerateSecurePassword(int length = 12)
        {
            if (length < 8) length = 8; // Minimum secure length

            var upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowerChars = "abcdefghijklmnopqrstuvwxyz";
            var numberChars = "0123456789";
            
            var password = new StringBuilder();
            
            // Ensure at least one of each required character type
            password.Append(upperChars[RandomNumberGenerator.GetInt32(upperChars.Length)]);
            password.Append(lowerChars[RandomNumberGenerator.GetInt32(lowerChars.Length)]);
            password.Append(numberChars[RandomNumberGenerator.GetInt32(numberChars.Length)]);
            password.Append(SpecialChars[RandomNumberGenerator.GetInt32(SpecialChars.Length)]);

            // Fill the rest with random characters
            var allChars = upperChars + lowerChars + numberChars + string.Join("", SpecialChars);
            
            for (int i = password.Length; i < length; i++)
            {
                password.Append(allChars[RandomNumberGenerator.GetInt32(allChars.Length)]);
            }

            // Shuffle the password
            return new string([.. password.ToString().ToCharArray().OrderBy(x => RandomNumberGenerator.GetInt32(length))]);
        }
    }
}
