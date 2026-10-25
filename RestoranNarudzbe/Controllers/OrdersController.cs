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
    public async Task<ActionResult<OrderResponse>> Create(CreateOrderRequest request)
    {
        var table = await _db.Tables
            .FirstOrDefaultAsync(x => x.Number == request.TableNumber);

        if (table is null)
        {
            ModelState.AddModelError(nameof(request.TableNumber), $"Table {request.TableNumber} does not exist.");
            return ValidationProblem(ModelState);
        }

        var menuItemIds = request.Items
            .Select(x => x.MenuItemId)
            .Distinct()
            .ToList();

        var menuItems = await _db.MenuItems
            .Where(x => menuItemIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id);

        var order = new Order
        {
            Table = table
        };

        foreach (var itemRequest in request.Items)
        {
            if (!menuItems.TryGetValue(itemRequest.MenuItemId, out var menuItem))
            {
                ModelState.AddModelError(nameof(request.Items), $"Menu item {itemRequest.MenuItemId} does not exist.");
                return ValidationProblem(ModelState);
            }

            if (!menuItem.IsAvailable)
            {
                ModelState.AddModelError(nameof(request.Items), $"Menu item '{menuItem.Name}' is not available.");
                return ValidationProblem(ModelState);
            }

            order.Items.Add(new OrderItem
            {
                MenuItemId = itemRequest.MenuItemId,
                Quantity = itemRequest.Quantity,
                Note = itemRequest.Note,
                Name = menuItem.Name,
                UnitPrice = menuItem.Price
            });
        }

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, OrderResponse.FromOrder(order));
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
