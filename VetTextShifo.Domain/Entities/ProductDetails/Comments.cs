using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.ProductDetails;

public class Comments : Auditable
{
    public string Name { get; set; }
    public string Comment { get; set; }
    public int ProductId { get; set; }
}
