using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities.ProductDetails.NewsModel;

public class NewsModelRus : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public DateTime CreateAt { get; set; }
}
