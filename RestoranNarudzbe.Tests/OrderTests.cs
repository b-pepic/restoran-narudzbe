using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Tests;

public class OrderTests
{
    [Fact]
    public void TotalPrice_MultipleItems_ReturnsSumOfItemTotals()
    {
        var order = new Order
        {
            Items =
            {
                new OrderItem { UnitPrice = 8.50m, Quantity = 2 },
                new OrderItem { UnitPrice = 12.00m, Quantity = 1 },
                new OrderItem { UnitPrice = 2.80m, Quantity = 3 }
            }
        };

        var total = order.TotalPrice;

        Assert.Equal(37.40m, total);
    }

    [Fact]
    public void TotalPrice_NoItems_ReturnsZero()
    {
        var order = new Order();

        var total = order.TotalPrice;

        Assert.Equal(0m, total);
    }

    [Fact]
    public void TotalPrice_DecimalPrice_IsExact()
    {
        var order = new Order
        {
            Items =
            {
                new OrderItem { UnitPrice = 0.1m, Quantity = 3 }
            }
        };

        var total = order.TotalPrice;

        Assert.Equal(0.3m, total);
    }
}