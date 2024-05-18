using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.DTOs.Users.Customer.ForView;

public class CustomerForView
{
    public string CustomerIp { get; set; }
    public List<Order> Orders { get; set; }
    public DateTime CreateAt { get; set; }
}
