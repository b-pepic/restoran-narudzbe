namespace RestoranNarudzbe.Models;

public class Order
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.New;
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalPrice
    {
        get { return Items.Sum(x => x.TotalPrice); }
    }
}
