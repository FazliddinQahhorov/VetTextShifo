using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.ProductDetails;

public class Comment : Auditable
{
    public string Name { get; set; }
    public string comment { get; set; }
    public string ProductModel { get; set; }
}
