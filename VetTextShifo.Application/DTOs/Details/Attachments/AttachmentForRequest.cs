using Microsoft.AspNetCore.Http;

namespace VetTextShifo.Application.DTOs.Details.Attachments;

public class AttachmentForRequest
{
    public List<IFormFile> attachments { get; set; }
}
