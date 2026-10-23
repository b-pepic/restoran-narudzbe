using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Data;

public static class InMemoryStore
{
    public static List<MenuItem> MenuItems { get; } = new()
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

    public static List<Order> Orders { get; } = new();
}
