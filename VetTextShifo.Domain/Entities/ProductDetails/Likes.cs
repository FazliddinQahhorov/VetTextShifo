using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.ProductDetails;

public class Likes : Auditable
{
    public string CustomerIP { get; set; }
    public string ProductModelName { get; set; }
}
