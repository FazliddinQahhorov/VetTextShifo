using Microsoft.AspNetCore.Http;
using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities.Attachments;
using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.Application.DTOs.Products.ForRequest;

public class ProductForUpdate
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
    
}
