namespace RestoranNarudzbe.Models;

public class OrderItem
{
    public int MenuItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public decimal TotalPrice
    {
        get { return Quantity * UnitPrice; }
    }
}