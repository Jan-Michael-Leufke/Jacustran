﻿namespace Jacustran.Persistence.DbContexts;

public class JacustranDbContext : DbContext //, IUnitOfWork
{
    public JacustranDbContext(DbContextOptions<JacustranDbContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Spot> Spots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JacustranDbContext).Assembly);

        
        // Seed data for testing

        modelBuilder.Entity<City>().HasData(
                new City()
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



        modelBuilder.Entity<Spot>().HasData(
            new Spot
            {
                Id = Guid.Parse("af871625-d754-4feb-8acd-c4f9ff13ba96"),
                Name = "Kiyomizu",
                Description = "An ancient Temple with a stunning View over Kyoto.",
                TownId = Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
                ImageUrl = "https://dummyimage.com/600x400/eee/aaa"
            },
            new Spot
            {
                Id = Guid.Parse("9384adfa-d754-4feb-8acd-c4f9ff13ba96"),
                Name = "Oyamazaki",
                Description = "A Neighbourhood with a certain melancholic feel.",
                TownId = Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
                ImageUrl = "https://dummyimage.com/600x400/eee/aaa"
            },
            new Spot
            {
                Id = Guid.Parse("9287afff-d754-4feb-8acd-c4f9ff13ba96"),
                Name = "Kinkakuji Temple",
                Description = "Colorful and with antique wooden structures ",
                TownId = Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
                ImageUrl = "https://dummyimage.com/600x400/eee/aaa"
            },
            new Spot
            {
                Id = Guid.Parse("8374adda-d754-4feb-8acd-c4f9ff13ba96"),
                Name = "Umeda",
                Description = "It´s a train station but also much more than that.",
                TownId = Guid.Parse("ac338e7a-d754-4feb-8acd-c4f9ff13ba96"),
                ImageUrl = "https://dummyimage.com/600x400/eee/aaa"
            });

        base.OnModelCreating(modelBuilder);
    }

   

    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    foreach (var entry in ChangeTracker.Entries<EntityBase>())
    //    {
    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.CreatedDate = DateTime.Now;
    //                entry.Entity.CreatedBy = "Jacustran";
    //                break;
    //            case EntityState.Modified:
    //                entry.Entity.LastModifiedDate = DateTime.Now;
    //                entry.Entity.LastModifiedBy = "Jacustran";
    //                break;
    //        }
    //    }

    //    return base.SaveChangesAsync(cancellationToken);
    //}

}
