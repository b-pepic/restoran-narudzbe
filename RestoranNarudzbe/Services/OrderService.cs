using Microsoft.EntityFrameworkCore;
using RestoranNarudzbe.Data;
using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _db;

    public OrderService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<OrderResponse>> GetAllAsync(OrderStatus? status, int? tableNumber)
    {
        IQueryable<Order> query = _db.Orders
            .Include(x => x.Table)
            .Include(x => x.Items);

        if (status is not null)
        {
            query = query.Where(x => x.Status == status);
        }

        if (tableNumber is not null)
        {
            query = query.Where(x => x.Table.Number == tableNumber);
        }

        query = query.OrderBy(x => x.CreatedAt);
        var orders = await query.ToListAsync();

        var orderResponses = orders.Select(x => OrderResponse.FromOrder(x)).ToList();

        return orderResponses;
    }

    public async Task<OrderResponse?> GetByIdAsync(int id)
    {
        var order = await _db.Orders
            .Include(x => x.Table)
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order is null)
            return null;

        var orderResponse = OrderResponse.FromOrder(order);
        return orderResponse;
    }

    public async Task<OrderResult> CreateOrderAsync(CreateOrderRequest request)
    {
        var table = await _db.Tables
            .FirstOrDefaultAsync(x => x.Number == request.TableNumber);

        if (table is null)
        {
            return OrderResult.Failure(OrderError.Invalid, $"Table {request.TableNumber} does not exist.");
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
                return OrderResult.Failure(OrderError.Invalid, $"Menu item {itemRequest.MenuItemId} does not exist.");
            }

            if (!menuItem.IsAvailable)
            {
                return OrderResult.Failure(OrderError.Invalid, $"Menu item '{menuItem.Name}' is not available.");
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

        return OrderResult.Success(OrderResponse.FromOrder(order));
    }

    public async Task<OrderResult> ChangeStatusAsync(int id, OrderStatus newStatus)
    {
        var order = await _db.Orders
            .Include(x => x.Table)
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order is null)
        {
            return OrderResult.Failure(OrderError.NotFound, $"Order {id} does not exist.");
        }

        if (!OrderStatusRules.CanChange(order.Status, newStatus))
        {
            return OrderResult.Failure(OrderError.Invalid,
                $"Cannot change status from {order.Status} to {newStatus}.");
        }

        order.Status = newStatus;
        order.UpdatedAt = DateTime.UtcNow;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return OrderResult.Failure(OrderError.Conflict, $"Order {id} was changed by someone else. Reload it and try again.");
        }

        return OrderResult.Success(OrderResponse.FromOrder(order));
    }
}
