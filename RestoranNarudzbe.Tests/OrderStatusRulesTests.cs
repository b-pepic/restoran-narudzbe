using RestoranNarudzbe.Models;
using RestoranNarudzbe.Services;

namespace RestoranNarudzbe.Tests;

public class OrderStatusRulesTests
{
    [Theory]
    [InlineData(OrderStatus.New, OrderStatus.Cancelled)]
    [InlineData(OrderStatus.New, OrderStatus.InProgress)]
    [InlineData(OrderStatus.InProgress, OrderStatus.Ready)]
    [InlineData(OrderStatus.Ready, OrderStatus.Served)]
    public void CanChange_AllowedTransition_ReturnsTrue(OrderStatus from, OrderStatus to)
    {
        var result = OrderStatusRules.CanChange(from, to);

        Assert.True(result);
    }

    [Theory]
    [InlineData(OrderStatus.Cancelled, OrderStatus.New)]
    [InlineData(OrderStatus.New, OrderStatus.Served)]
    [InlineData(OrderStatus.InProgress, OrderStatus.Cancelled)]
    [InlineData(OrderStatus.Ready, OrderStatus.New)]
    [InlineData(OrderStatus.New, OrderStatus.New)]
    [InlineData(OrderStatus.Served, OrderStatus.New)]
    [InlineData(OrderStatus.New, OrderStatus.Ready)]
    public void CanChange_ForbiddenTransition_ReturnsFalse(OrderStatus from, OrderStatus to)
    {
        var result = OrderStatusRules.CanChange(from, to);

        Assert.False(result);
    }
}
