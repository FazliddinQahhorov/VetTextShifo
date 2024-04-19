using Microsoft.AspNetCore.Http;

namespace VetTextShifo.Application.DTOs.Details.Location;

public class LocationForCreation
{
    public string Sity { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public long Postcode { get; set; }
    public IFormFile File { get; set; }
}
