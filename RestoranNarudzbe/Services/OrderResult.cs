using RestoranNarudzbe.Dtos;

namespace RestoranNarudzbe.Services;

public class OrderResult
{
    private OrderResult(OrderResponse order)
    {
        Order = order;
    }

    private OrderResult(OrderError error, string message)
    {
        Error = error;
        ErrorMessage = message;
    }

    public OrderResponse? Order { get; }
    public OrderError? Error { get; }
    public string? ErrorMessage { get; }
    public bool IsSuccess => Error is null;

    public static OrderResult Success(OrderResponse order) => new(order);
    public static OrderResult Failure(OrderError error, string message) => new(error, message);
}
