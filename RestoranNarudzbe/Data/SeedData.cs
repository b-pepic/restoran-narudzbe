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
            db.MenuItems.AddRange(MenuSeedData.GetMenuItems());
        }

        db.SaveChanges();
    }
}