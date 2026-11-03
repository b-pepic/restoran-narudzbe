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
}
