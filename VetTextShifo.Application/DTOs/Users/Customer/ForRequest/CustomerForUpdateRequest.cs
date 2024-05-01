using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.DTOs.Users.Customer.ForRequest;

public class CustomerForUpdateRequest
{
    public List<Likes> Likes { get; set; }
    public List<Order> Orders { get; set; }
    public int ProductId { get; set; }
}
