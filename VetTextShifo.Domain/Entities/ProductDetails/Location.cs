using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.Attachments;

namespace VetTextShifo.Domain.Entities.ProductDetails;

public class Location : Auditable
{
    public string Sity { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public long Postcode { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
