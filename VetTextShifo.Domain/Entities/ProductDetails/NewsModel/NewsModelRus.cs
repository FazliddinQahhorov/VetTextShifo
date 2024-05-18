using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.Attachments;

namespace VetTextShifo.Domain.Entities.ProductDetails.NewsModel;

public class NewsModelRus : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public AttachmentForNew Attachment { get; set; }
}
