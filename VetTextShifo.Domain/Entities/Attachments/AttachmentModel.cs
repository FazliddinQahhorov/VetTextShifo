using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.Attachments;

public class AttachmentModel : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public int ProductEngId { get; set; }
    public int ProductRusId { get; set; }
    public int ProductUzbId { get; set; }
}
