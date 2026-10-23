using Microsoft.AspNetCore.Mvc;
using RestoranNarudzbe.Data;
using RestoranNarudzbe.Dtos;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<MenuItem>> GetAll()
    {
        return Ok(InMemoryStore.MenuItems);
    }

    [HttpGet("{id}")]
    public ActionResult<MenuItem> GetById(int id)
    {
        var item = InMemoryStore.MenuItems.FirstOrDefault(x => x.Id == id);
        if (item is null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult<MenuItem> Create(CreateMenuItemRequest request)
    {
        var newId = InMemoryStore.MenuItems.Count == 0 ? 1 : InMemoryStore.MenuItems.Max(x => x.Id) + 1;
        var newMenuItem = new MenuItem
        {
            Id = newId,
            Name = request.Name,
            Price = request.Price,
            Category = request.Category
        };
        InMemoryStore.MenuItems.Add(newMenuItem);
        return CreatedAtAction(nameof(GetById), new { id = newMenuItem.Id }, newMenuItem);
    }
}
