using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.Domain.Entities.Users;

public class Customer : Auditable
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Likes> Likes { get; set; }
    public List<Order> Orders { get; set; }
    public DateTime CreateAt { get; set; }
    public int ProductId { get; set; }
}
