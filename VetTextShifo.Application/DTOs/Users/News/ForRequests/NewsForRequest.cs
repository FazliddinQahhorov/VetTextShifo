using Microsoft.AspNetCore.Http;
using VetTextShifo.Application.DTOs.Details.Attachments;
using VetTextShifo.Domain.Entities.Attachments;

namespace VetTextShifo.Application.DTOs.Users.News.ForRequests;

public class NewsForRequest
{
    public int id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
