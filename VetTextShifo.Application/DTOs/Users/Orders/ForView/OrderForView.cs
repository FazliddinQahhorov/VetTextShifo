namespace VetTextShifo.Application.DTOs.Users.Orders.ForView;

public class OrderForView
{
    public int id { get; set; }
    public string ProductModelName { get; set; }
    public string CustomerName { get; set; }
    public string CustomerNumber { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
