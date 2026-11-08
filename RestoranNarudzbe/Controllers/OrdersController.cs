using Microsoft.AspNetCore.Mvc;
using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;
using RestoranNarudzbe.Services;

namespace RestoranNarudzbe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAll(OrderStatus? status, int? tableNumber)
    {
        var orders = await _orderService.GetAllAsync(status, tableNumber);
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create(CreateOrderRequest request)
    {
        var result = await _orderService.CreateOrderAsync(request);
        if (!result.IsSuccess)
        {
            return ValidationProblem(detail: result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Order!.Id }, result.Order);
    }

    [HttpPatch("{id}/status")]
    public async Task<ActionResult<OrderResponse>> UpdateStatus(int id, UpdateOrderStatusRequest request)
    {
        var result = await _orderService.ChangeStatusAsync(id, request.Status!.Value);
        if (!result.IsSuccess)
        {
            if (result.Error == OrderError.NotFound)
            {
                return NotFound();
            }

            if (result.Error == OrderError.Invalid)
            {
                return ValidationProblem(detail: result.ErrorMessage);
            }
        }

        return Ok(result.Order);
    }
}
