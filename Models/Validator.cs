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
    }
}
