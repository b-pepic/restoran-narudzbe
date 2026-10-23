using Microsoft.AspNetCore.Mvc;
using RestoranNarudzbe.Data;
using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<Order> GetById(int id)
    {
        var item = InMemoryStore.Orders.FirstOrDefault(x => x.Id == id);
        if (item is null)
            return NotFound();
        return Ok(item);
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
            TableNumber = request.TableNumber,
            CreatedAt = DateTime.UtcNow,
            Items = orderItems
        };
        InMemoryStore.Orders.Add(newOrder);
        return CreatedAtAction(nameof(GetById), new { id = newId }, newOrder);
    }
}
