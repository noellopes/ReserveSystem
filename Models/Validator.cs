using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReserveSystem.Models
{
    public static class Validator
    {
        public static bool IsNifValid(string Nif)
        {
            if (string.IsNullOrWhiteSpace(Nif) || Nif.Length != 9 || !Nif.All(char.IsDigit))
            {
                return false;
            }
            var digits = Nif.Select(ch => int.Parse(ch.ToString())).ToArray();

            if (!new[] { 1, 2, 5, 6, 7, 8, 9 }.Contains(digits[0]))
            {
                return false;
            }

            int checksum = 0;
            for (int i = 0; i < 8; i++)
            {
                checksum += digits[i] * (9 - i);
            }

            int checkDigit = 11 - (checksum % 11);

            if (checkDigit >= 10)
            {
                checkDigit = 0;
            }

            return checkDigit == digits[8];
        }

        public static bool IsIDCardValid(string IDCard)
        {
            if (string.IsNullOrWhiteSpace(IDCard)) return false;

            IDCard = IDCard.Trim();
            if (char.IsDigit(IDCard[0]))
            {
                // If it starts with a digit, length must be between 8 and 18
                return IDCard.Length >= 8 && IDCard.Length <= 18;
            }
            else if (char.IsLetter(IDCard[0]))
            {
                // If it starts with a letter, match the regex pattern
                var pattern = @"^[A-Z]{1,2}\d{6,8}$";
                return Regex.IsMatch(IDCard, pattern);
            }
            return false;
        }

        public static bool IsPassportValid(string passportNumber)
        {
            if (string.IsNullOrWhiteSpace(passportNumber)) return false;

            passportNumber = passportNumber.Trim();
            if (char.IsDigit(passportNumber[0]))
            {
                // If it starts with a digit, length must be between 8 and 18
                return passportNumber.Length >= 8 && passportNumber.Length <= 12;
            }
            else if (char.IsLetter(passportNumber[0]))
            {
                // If it starts with a letter, match the regex pattern
                var pattern = @"^[A-Z]{1,2}\d{6,8}$";
                return Regex.IsMatch(passportNumber, pattern);
            }
            return false;          
        }
    }
}
