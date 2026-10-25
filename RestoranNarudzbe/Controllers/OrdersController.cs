using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranNarudzbe.Data;
using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _db;

    public OrdersController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAll(OrderStatus? status)
    {
        IQueryable<Order> query = _db.Orders
            .Include(x => x.Items)
            .Include(x => x.Table);

        if (status is not null)
        {
            query = query.Where(x => x.Status == status);
        }

        query = query.OrderBy(x => x.CreatedAt);
        var orders = await query.ToListAsync();

        var ordersResponse = orders.Select(x => OrderResponse.FromOrder(x))
            .ToList();

        return Ok(ordersResponse);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> GetById(int id)
    {
        var order = await _db.Orders
            .Include(x => x.Table)
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order is null)
            return NotFound();

        var orderResponse = OrderResponse.FromOrder(order);
        return Ok(orderResponse);
    }

    [HttpPost]
    public ActionResult<Order> Create(CreateOrderRequest request)
    {
        List<OrderItem> orderItems = new();

        foreach (var itemRequest in request.Items)
        {
            var menuItem = InMemoryStore.MenuItems.FirstOrDefault(x => x.Id == itemRequest.MenuItemId);
            if (menuItem is null)
            {
                ModelState.AddModelError(nameof(request.Items), $"Menu item {itemRequest.MenuItemId} does not exist.");
                return ValidationProblem(ModelState);
            }
            orderItems.Add(new OrderItem
            {
                MenuItemId = itemRequest.MenuItemId,
                Quantity = itemRequest.Quantity,
                Note = itemRequest.Note,
                Name = menuItem.Name,
                UnitPrice = menuItem.Price
            });
        }

        var newId = InMemoryStore.Orders.Count == 0 ? 1 : InMemoryStore.Orders.Max(x => x.Id) + 1;
        var newOrder = new Order
        {
            Id = newId,
            TableId = request.TableNumber, // TODO faza 2, korak 6: naci stol po broju u bazi
            CreatedAt = DateTime.UtcNow,
            Items = orderItems
        };
        InMemoryStore.Orders.Add(newOrder);
        return CreatedAtAction(nameof(GetById), new { id = newId }, newOrder);
    }

    [HttpPatch("{id}/status")]
    public ActionResult<Order> UpdateStatus(int id, UpdateOrderStatusRequest request)
    {
        var order = InMemoryStore.Orders.FirstOrDefault(x => x.Id == id);

        if (order is null)
        {
            return NotFound();
        }

        order.Status = request.Status!.Value;
        order.UpdatedAt = DateTime.UtcNow;
        return Ok(order);
    }
}
