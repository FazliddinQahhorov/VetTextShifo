using VetTextShifo.Application.DTOs.Details.Attachments;
using VetTextShifo.Domain.Entities.Attachments;

namespace VetTextShifo.Application.DTOs.Users.News.ForResponse;

public class NewsForResponce
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AttachmentForResponse Attachments { get; set; }
    public DateTime Created { get; set; }
}
