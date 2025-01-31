﻿using Microsoft.AspNetCore.Http;

namespace VetTextShifo.Application.DTOs.Products.ForView;

public class ProductForMainView
{
    public int id { get; set; }
    public string ModelName { get; set; }
    public string BrandName { get; set; }
    public string GuaranteePeriod { get; set; }
    public bool Service { get; set; }
    public string MadeIn { get; set; }
    public string Produced { get; set; }
    public string ExtraDevices { get; set; }
    public string Description { get; set; }
    public string PaymentType { get; set; }
    public bool PaymentContract { get; set; }
    public int LikeCount { get; set; }
    public int Rating { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
}
