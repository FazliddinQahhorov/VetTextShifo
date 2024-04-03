using Microsoft.AspNetCore.Http;

namespace VetTextShifo.Application.DTOs.Products.ForRequest;

public class NewForCreate
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
    public DateTime CreateAt { get; set; }
}
