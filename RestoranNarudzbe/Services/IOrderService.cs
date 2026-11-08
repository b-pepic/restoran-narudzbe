using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Services;

public interface IOrderService
{
    Task<List<OrderResponse>> GetAllAsync(OrderStatus? status, int? tableNumber);
    Task<OrderResponse?> GetByIdAsync(int id);
    Task<OrderResult> CreateOrderAsync(CreateOrderRequest request);
    Task<OrderResult> ChangeStatusAsync(int id, OrderStatus newStatus);
}
