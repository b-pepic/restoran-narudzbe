using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Services;

public static class OrderStatusRules
{
    public static bool CanChange(OrderStatus from, OrderStatus to)
        => (from, to) switch
        {
            (OrderStatus.New, OrderStatus.InProgress) => true,
            (OrderStatus.New, OrderStatus.Cancelled) => true,
            (OrderStatus.InProgress, OrderStatus.Ready) => true,
            (OrderStatus.Ready, OrderStatus.Served) => true,
            _ => false
        };
}
