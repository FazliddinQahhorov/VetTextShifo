using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.Users;

public class Order : Auditable
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
