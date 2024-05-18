using System.ComponentModel.DataAnnotations;
using VetTextShifo.Application.Attributes;

namespace VetTextShifo.Application.DTOs.Users.Orders.ForRequest;

public class OrderForRequest
{
    [Required(ErrorMessage = "Maxsulot nomini kiriting")]
    public string ProductModelName { get; set; }
    [Required(ErrorMessage = "Ismingizni kiriting!")]
    public string CustomerName { get; set; }
    [Required(ErrorMessage = "Telefon raqamingizni kiriting"), PhoneNumber]
    public string CustomerNumber { get; set; }
}
