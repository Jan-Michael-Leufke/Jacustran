using Microsoft.EntityFrameworkCore;

namespace Jacustran.Persistence.DbContexts;

public class JacustranDbContext : DbContext
{
    public JacustranDbContext(DbContextOptions<JacustranDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    //public DbSet<Category> Categories { get; set; }
    //public DbSet<City> Cities { get; set; }
    //public DbSet<Spot> Spots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JacustranDbContext).Assembly);

        
        // Seed data for testing

        modelBuilder.Entity<City>().HasData(
                new City
                { 
                    Id = Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Kyoto",
                    Description = "Kyoto is the culural capital of japan",
                    Population = 1_475_000,
                    ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                    IsImportantCity = true
                },
                new City
                {
                    Id = Guid.Parse("fdbead28-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Tokyo",
                    Description = "Tokyo is a megacity",
                    Population = 13_960_000,
                    ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                    IsImportantCity = true
                },
                new City
                {
                    Id = Guid.Parse("ac338e7a-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Osaka",
                    Population = 2_691_000,
                    Description = "Osaka lies in the kanto area",
                    ImageUrl = "https://dummyimage.com/600x400/eee/aaa",
                    IsImportantCity = true
                });



        //modelBuilder.Entity<Spot>().HasData(
        //    new Spot
        //    {
        //        Id = Guid.Parse("spot-guid-1"),
        //        Name = "Spot 1",
        //        Description = "This is Spot 1",
        //        CityId = Guid.Parse("city-guid-1"),
        //        ImageUrl = "https://dummyimage.com/600x400/eee/aaa"
        //    },
        //    new Spot
        //    {
        //        Id = Guid.Parse("spot-guid-2"),
        //        Name = "Spot 2",
        //        Description = "This is Spot 2",
        //        CityId = Guid.Parse("city-guid-2"),
        //        ImageUrl = "https://dummyimage.com/600x400/eee/aaa"
        //    },
        //    new Spot
        //    {
        //        Id = Guid.Parse("spot-guid-3"),
        //        Name = "Spot 3",
        //        Description = "This is Spot 3",
        //        CityId = Guid.Parse("city-guid-3"),
        //        ImageUrl = "https://dummyimage.com/600x400/eee/aaa"
        //    });

        base.OnModelCreating(modelBuilder);
    }



public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch(entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "Jacustran";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "Jacustran";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}
