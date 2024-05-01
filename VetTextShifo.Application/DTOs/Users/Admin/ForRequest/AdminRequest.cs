using System.ComponentModel.DataAnnotations;

namespace VetTextShifo.Application.DTOs.Users.Customer.ForRequest;

public class AdminRequest
{
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
}
