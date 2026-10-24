namespace RestoranNarudzbe.Models;

public class Order
{
    public int Id { get; set; }
    public int TableId { get ; set; }
    public Table Table { get; set; } = null!;
    public OrderStatus Status { get; set; } = OrderStatus.New;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalPrice
    {
        get { return Items.Sum(x => x.TotalPrice); }
    }
}
