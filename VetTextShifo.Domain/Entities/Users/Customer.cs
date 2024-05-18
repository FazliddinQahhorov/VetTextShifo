using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.Domain.Entities.Users;

public class Customer : Auditable
{
    public string CustomerIp { get; set; }
    public List<Order> Orders { get; set; }
    public DateTime CreateAt { get; set; }
}
