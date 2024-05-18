using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.NewsModel;

namespace VetTextShifo.Domain.Entities.Attachments;

public class AttachmentForNew : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }

    public int NewsModelEngId { get; set; }
    public NewsModelEng NewsModelEng { get; set; }
    public int NewsModelRusId { get; set; }
    public NewsModelRus NewsModelRus { get; set; }
    public int NewsModelUzbId { get; set; }
    public NewsModelUzb NewsModelUzb { get; set; }
}
