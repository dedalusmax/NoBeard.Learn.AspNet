using Microsoft.EntityFrameworkCore;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Data;

public sealed class PetShopSeeder
{
    public bool Seed(DbContext context)
    {
        if (context.Set<PetShop>().Count() < 3)
        {
            var petShops = new List<PetShop>
            {
                new PetShop { Name = "Purrfect Pets", Address = "789 Oak St" },
                new PetShop { Name = "Paw Patrol", Address = "321 Pine St" },
                new PetShop { Name = "Snoop Dogg", Address = "654 Maple St" },
            };

            context.Set<PetShop>().AddRange(petShops);
            context.SaveChanges();
        }
        return true; // Data seeded successfully
    }
}
