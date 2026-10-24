using Microsoft.EntityFrameworkCore;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Data;

public static class SeedData
{
    public static void Seed(DbContext context, bool storeManagementPerformed)
    {
        var db = (AppDbContext)context;

        if (!db.Tables.Any())
        {
            for (var number = 1; number <= 8; number++)
            {
                db.Tables.Add(new Table { Number = number, Seats = number <= 4 ? 2 : 4 });
            }
        }

        if (!db.MenuItems.Any())
        {
            db.MenuItems.AddRange(
                new MenuItem { Name = "Margherita", Price = 9.50m, Category = "Pizza" },
                new MenuItem { Name = "Capricciosa", Price = 11.00m, Category = "Pizza" },
                new MenuItem { Name = "Cevapi", Price = 10.50m, Category = "Grill" },
                new MenuItem { Name = "Pljeskavica", Price = 11.50m, Category = "Grill" },
                new MenuItem { Name = "Spaghetti Carbonara", Price = 10.00m, Category = "Pasta" },
                new MenuItem { Name = "Caesar Salad", Price = 8.00m, Category = "Salad" },
                new MenuItem { Name = "Tomato Soup", Price = 4.50m, Category = "Soup" },
                new MenuItem { Name = "Pancakes", Price = 5.00m, Category = "Dessert" },
                new MenuItem { Name = "Coca-Cola", Price = 3.00m, Category = "Drinks" },
                new MenuItem { Name = "Espresso", Price = 1.80m, Category = "Drinks" });
        }

        db.SaveChanges();
    }
}