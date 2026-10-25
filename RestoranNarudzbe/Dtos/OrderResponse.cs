using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Dtos;

public class OrderResponse
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItemResponse> Items { get; set; } = new();

    public static OrderResponse FromOrder(Order order)
    {
        var orderResponse = new OrderResponse
        {
            Id = order.Id,
            TableNumber = order.Table.Number,
            Status = order.Status,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt,
            TotalPrice = order.TotalPrice,
            Items = order.Items.Select(x => OrderItemResponse.FromOrderItem(x)).ToList()
        };
        return orderResponse;
    }
}
