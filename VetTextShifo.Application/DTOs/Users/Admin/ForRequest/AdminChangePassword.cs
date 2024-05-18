using System.ComponentModel.DataAnnotations;
using VetTextShifo.Application.Attributes;

namespace VetTextShifo.Application.DTOs.Users.Customer.ForRequest
{
    public class AdminChangePassword
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Eski Parolni kiriting")]  
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Yangi Parolni kiriting"), StrongPassword]
        public string NewPassword { get; set; }
    }
}
