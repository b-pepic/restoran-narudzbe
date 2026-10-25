using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Dtos;

public class OrderItemResponse
{
    public int Id { get; set; }
    public int MenuItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public decimal TotalPrice { get; set; }

    public static OrderItemResponse FromOrderItem(OrderItem item)
    {
        var orderItemResponse = new OrderItemResponse()
        {
            Id = item.Id,
            MenuItemId = item.MenuItemId,
            Name = item.Name,
            UnitPrice = item.UnitPrice,
            Quantity = item.Quantity,
            Note = item.Note,
            TotalPrice = item.TotalPrice
        };
        return orderItemResponse;
    }
}
