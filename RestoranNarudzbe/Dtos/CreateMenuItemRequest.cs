using System.ComponentModel.DataAnnotations;

namespace RestoranNarudzbe.Dtos;

public class CreateMenuItemRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 1000)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(50)]
    public string Category { get; set; } = string.Empty;
}

