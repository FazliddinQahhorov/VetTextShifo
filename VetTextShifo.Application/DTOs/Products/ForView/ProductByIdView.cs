﻿using VetTextShifo.Application.DTOs.Details.Attachments;
using VetTextShifo.Domain.Entities.ProductDetails;


namespace VetTextShifo.Application.DTOs.Products.ForView;

public class ProductByIdView
{
    public int id { get; set; }
    public string ModelName { get; set; }
    public string BrandName { get; set; }
    public string Description { get; set; }
    public int LikeCount { get; set; }
    public List<AttachmentForResponse> Files { get; set; }
    public List<Comment> comments { get; set; }

}
