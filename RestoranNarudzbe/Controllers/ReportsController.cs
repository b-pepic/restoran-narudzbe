using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranNarudzbe.Data;
using RestoranNarudzbe.Dtos;

namespace RestoranNarudzbe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ReportsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("order-totals")]
    public async Task<ActionResult<IEnumerable<OrderTotalResponse>>> GetOrderTotals()
    {
        var totals = await _db.Orders
            .OrderBy(x => x.Id)
            .Select(order => new OrderTotalResponse
            {
                OrderId = order.Id,
                TableNumber = order.Table.Number,
                TotalPrice = order.Items.Sum(item => item.Quantity * item.UnitPrice)
            })
            .ToListAsync();

        return Ok(totals);
    }

    [HttpGet("top-menu-items")]
    public async Task<ActionResult<IEnumerable<TopMenuItemResponse>>> GetTopMenuItems([Range(1, 50)] int count = 5)
    {
        var topMenuItems = await _db.OrderItems
            .GroupBy(item => new { item.MenuItemId, item.MenuItem.Name })
            .Select(group => new TopMenuItemResponse
            {
                MenuItemId = group.Key.MenuItemId,
                Name = group.Key.Name,
                QuantitySold = group.Sum(item => item.Quantity)
            })
            .OrderByDescending(itemResponse => itemResponse.QuantitySold)
            .ThenBy(itemResponse => itemResponse.Name)
            .Take(count)
            .ToListAsync();

        return Ok(topMenuItems);
    }
}
