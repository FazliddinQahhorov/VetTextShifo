namespace VetTextShifo.Domain.Entities.ProductDetails.Products;

using System.Text.Json.Serialization;
using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.Attachments;

public class ProductUzb : Auditable
{
    public string ModelName { get; set; }
    public string BrandName { get; set; }
    public string GuaranteePeriod { get; set; }
    public bool Service { get; set; }
    public string MadeIn { get; set; }
    public string Produced { get; set; }
    public string ExtraDevices { get; set; }
    public string PaymentType { get; set; }
    public bool PaymentContract { get; set; }
    public string Description { get; set; }
    public int LikeCount { get; set; }
    public int Rating { get; set; }
    public List<AttachmentModel> attachments { get; set; }
    public List<Comment> comments { get; set; }

}
