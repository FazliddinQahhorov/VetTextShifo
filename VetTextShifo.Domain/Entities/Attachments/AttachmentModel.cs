using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Domain.Entities.Attachments;

public class AttachmentModel : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public int ProductEngId { get; set; }
    public ProductEng ProductEng { get; set; }
    public int ProductRusId { get; set; }
    public ProductRus ProductRus { get; set; }
    public int ProductUzbId { get; set; }
    public ProductUzb ProductUzb { get; set; }
}
