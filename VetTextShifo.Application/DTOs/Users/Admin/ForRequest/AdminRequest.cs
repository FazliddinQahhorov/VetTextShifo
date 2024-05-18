using System.ComponentModel.DataAnnotations;
using VetTextShifo.Application.Attributes;

namespace VetTextShifo.Application.DTOs.Users.Customer.ForRequest;

public class AdminRequest
{
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Parolni kiriting"), StrongPassword]
    public string Password { get; set; }
    [Required(ErrorMessage = "Parolni kiriting"), StrongPassword]
    public string ConfirmPassword { get; set; }
}
