using Microsoft.EntityFrameworkCore;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Data;

public class PetShopContext : DbContext
{
    public DbSet<PetShop> PetShops { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<PetType> PetTypes { get; set; }

    public DbSet<AnimalFood> AnimalFoods { get; set; }

    public PetShopContext()
    {

    }

    public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetShopDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        //optionsBuilder.UseSeeding((dbContext, seed) => {
        //    // TODO: Implement seeding logic here if needed, or call a seeder class to seed the database.   
        //});

        optionsBuilder.UseSeeding((dbContext, _) => new PetShopSeeder().Seed(dbContext));

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

        // SET IDENTITY_INSERT ON for PetShop table

        modelBuilder.Entity<PetShop>().HasData(
            new PetShop { Id = 1, Name = "Happy Paws", Address = "123 Main St" },
            new PetShop { Id = 2, Name = "Furry Friends", Address = "456 Elm St" }
        );

        // SET IDENTITY_INSERT OFF for PetShop table

        // SET IDENTITY_INSERT ON for PetType table

        modelBuilder.Entity<PetType>().HasData(
            new PetType { Id = 1, Name = "Dog" },
            new PetType { Id = 2, Name = "Cat" },
            new PetType { Id = 3, Name = "Bird" }
        );  

        base.OnModelCreating(modelBuilder);
    }

}
