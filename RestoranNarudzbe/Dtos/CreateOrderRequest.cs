using System.ComponentModel.DataAnnotations;

namespace RestoranNarudzbe.Dtos;

public class CreateOrderRequest
{
    [Range(1, 50)]
    public int TableNumber { get; set; }

    [Required]
    [MinLength(1)]
    public List<CreateOrderItemRequest> Items { get; set; } = new();
}
