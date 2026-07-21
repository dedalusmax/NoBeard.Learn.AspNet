using Microsoft.EntityFrameworkCore;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Data;

public class PetShopContext : DbContext
{
    public DbSet<PetShop> PetShops { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<PetType> PetTypes { get; set; }

    public PetShopContext()
    {

    }

    public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetShopDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API configurations can be added here if needed

        //modelBuilder.Entity<PetShop>()
        //    .HasKey(p => p.Id);

        //modelBuilder.Entity<PetType>()
        //    .Property(pt => pt.Name).HasMaxLength(50)
        //    .IsRequired();

        modelBuilder.Entity<PetShop>()
            .HasIndex(x => new { x.Name, x.Address })
            .IsUnique();

        modelBuilder.Entity<Pet>()
            .HasIndex(x => x.Name)
            .IsUnique();

        //modelBuilder.Entity<PetShop>()
        //    .HasMany(p => p.Pets)
        //    .WithOne(p => p.PetShop)
        //    .HasForeignKey(p => p.PetShopId)
        //    .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

}
