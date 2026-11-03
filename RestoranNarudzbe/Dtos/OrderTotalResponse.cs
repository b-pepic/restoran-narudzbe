namespace RestoranNarudzbe.Dtos;

public class OrderTotalResponse
{
    public int OrderId { get; set; }
    public int TableNumber { get; set; }
    public decimal TotalPrice { get; set; }
}
