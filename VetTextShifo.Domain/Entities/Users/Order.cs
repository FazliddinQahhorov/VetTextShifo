using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.Users;

public class Order : Auditable
{
    public string ProductModelName { get; set; }
    public string CustomerName { get; set; }
    public string CustomerNumber { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
