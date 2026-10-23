using RestoranNarudzbe.Models;
using System.ComponentModel.DataAnnotations;

namespace RestoranNarudzbe.Dtos;

public class UpdateOrderStatusRequest
{
    [Required]
    [EnumDataType(typeof(OrderStatus))]
    public OrderStatus? Status { get; set; }
}
