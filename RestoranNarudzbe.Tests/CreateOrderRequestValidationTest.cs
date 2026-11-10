using System.ComponentModel.DataAnnotations;
using RestoranNarudzbe.Dtos;

namespace RestoranNarudzbe.Tests;

public class CreateOrderRequestValidationTests
{
    [Fact]
    public void Validate_ValidRequest_HasNoErrors()
    {
        var request = new CreateOrderRequest
        {
            TableNumber = 3,
            Items =
            {
                new CreateOrderItemRequest { MenuItemId = 64, Quantity = 1 }
            }
        };

        var results = Validate(request);

        Assert.Empty(results);
    }

    [Fact]
    public void Validate_NoItems_ReturnsItemsError()
    {
        var request = new CreateOrderRequest
        {
            TableNumber = 3
        };

        var results = Validate(request);

        Assert.Contains(results, result => result.MemberNames.Contains(nameof(CreateOrderRequest.Items)));
    }

    [Fact]
    public void Validate_ZeroQuantity_ReturnsQuantityError()
    {
        var item = new CreateOrderItemRequest
        {
            MenuItemId = 64,
            Quantity = 0
        };

        var results = Validate(item);

        Assert.Contains(results, result => result.MemberNames.Contains(nameof(CreateOrderItemRequest.Quantity)));
    }

    private static List<ValidationResult> Validate(object model)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(model, new ValidationContext(model), results, validateAllProperties: true);
        return results;
    }
}