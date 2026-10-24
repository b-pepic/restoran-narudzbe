namespace RestoranNarudzbe.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; } = null!;
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public decimal TotalPrice
    {
        get { return Quantity * UnitPrice; }
    }
}