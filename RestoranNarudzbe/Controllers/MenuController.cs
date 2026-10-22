using Microsoft.AspNetCore.Mvc;
using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private static readonly List<MenuItem> _menu = new()
    {
        new() { Id = 1, Name = "Margherita", Price = 8.50m, Category = "Pizza" },
        new() { Id = 2, Name = "Capricciosa", Price = 11.00m, Category = "Pizza" },
        new() { Id = 3, Name = "Quattro formaggi", Price = 12.50m, Category = "Pizza" },
        new() { Id = 4, Name = "Carbonara", Price = 10.00m, Category = "Pasta" },
        new() { Id = 5, Name = "Bolognese", Price = 9.50m, Category = "Pasta" },
        new() { Id = 6, Name = "Pljukanci s tartufima", Price = 16.00m, Category = "Pasta" },
        new() { Id = 7, Name = "Paški sir", Price = 12.00m, Category = "Predjelo" },
        new() { Id = 8, Name = "Juha od rajčice", Price = 5.50m, Category = "Predjelo" },
        new() { Id = 9, Name = "Coca-Cola 0,33", Price = 3.50m, Category = "Piće" },
        new() { Id = 10, Name = "Točeno pivo 0,5", Price = 4.00m, Category = "Piće" },
    };

    [HttpGet]
    public ActionResult<IEnumerable<MenuItem>> GetAll()
    {
        return Ok(_menu);
    }

    [HttpGet("{id}")]
    public ActionResult<MenuItem> GetById(int id)
    {
        var item = _menu.FirstOrDefault(x => x.Id == id);
        if (item is null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult<MenuItem> Create(CreateMenuItemRequest request)
    {
        var newId = _menu.Count == 0 ? 1 : _menu.Max(x => x.Id) + 1;
        var newMenuItem = new MenuItem
        {
            Id = newId,
            Name = request.Name,
            Price = request.Price,
            Category = request.Category
        };
        _menu.Add(newMenuItem);
        return CreatedAtAction(nameof(GetById), new { id = newMenuItem.Id }, newMenuItem);
    }
}
