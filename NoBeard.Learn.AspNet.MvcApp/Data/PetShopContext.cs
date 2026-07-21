using Microsoft.EntityFrameworkCore;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Data;

public class PetShopContext : DbContext
{
    public DbSet<PetShop> PetShops { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<PetType> PetTypes { get; set; }

    public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetShopDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API configurations can be added here if needed

        base.OnModelCreating(modelBuilder);
    }

}
