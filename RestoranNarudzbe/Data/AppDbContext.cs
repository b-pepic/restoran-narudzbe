using Microsoft.EntityFrameworkCore;
using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<MenuItem> MenuItems => Set<MenuItem>();

    public DbSet<Table> Tables => Set<Table>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
}