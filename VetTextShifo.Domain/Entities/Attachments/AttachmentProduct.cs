using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.Attachments;

public class AttachmentProduct : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public int ProductId { get; set; }
}
