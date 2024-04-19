using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.ProductDetails;

public class Likes : Auditable
{
    public int CustomerIP { get; set; }
    public int ProductId { get; set; }
}
