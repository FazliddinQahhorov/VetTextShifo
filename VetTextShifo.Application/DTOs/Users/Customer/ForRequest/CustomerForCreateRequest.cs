using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.DTOs.Users.Customer.ForRequest;

public class CustomerForCreateRequest
{
    public string CustomerIp { get; set; }
    public DateTime CreateAt { get; set; }
    public int ProductId { get; set; }
}
