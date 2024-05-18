using System;
using System.Linq;

namespace VetTextShifo.Application.Validators
{
    public static class PasswordValidator
    {
        public static (bool IsValid, string Message) IsStrong(string password)
        {
            bool containsDigit = password.Any(char.IsDigit);
            bool containsLetter = password.Any(char.IsLetter);

            if (!containsDigit || !containsLetter || password.Length < 8)
            {
                return (IsValid: false, Message: "Password must contain at least 1 digit and 1 letter and must be at least 8 characters long.");
            }

            return (IsValid: true, Message: "Valid password!");
        }
    }
}
