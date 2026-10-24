using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranNarudzbe.Data;
using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly AppDbContext _db;

    public MenuController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItem>>> GetAll()
    {
        var items = await _db.MenuItems
            .OrderBy(x => x.Id)
            .ToListAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MenuItem>> GetById(int id)
    {
        var item = await _db.MenuItems.FindAsync(id);
        if (item is null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<MenuItem>> Create(CreateMenuItemRequest request)
    {
        var newMenuItem = new MenuItem
        {
            Name = request.Name,
            Price = request.Price,
            Category = request.Category
        };

        _db.MenuItems.Add(newMenuItem);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = newMenuItem.Id }, newMenuItem);
    }
}