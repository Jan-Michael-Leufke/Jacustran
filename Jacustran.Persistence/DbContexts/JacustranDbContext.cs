using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Microsoft.Extensions.Logging;
using Jacustran.Domain.Enumerations;
using System.Drawing;
using MediatR;

namespace Jacustran.Persistence.DbContexts;

public class JacustranDbContext : DbContext //, IUnitOfWork
{
    private readonly IMediator _mediator;

    public JacustranDbContext(DbContextOptions<JacustranDbContext> options, IMediator mediator) : base(options)  => _mediator = mediator;

    //private JacustranDbContext() { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<City> Cities  => Set<City>();  
    public DbSet<Spot> Spots  => Set<Spot>();

    //private StreamWriter _writer = new StreamWriter("EfCoreLogs.txt", append: true);


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = JacustranLocalDb");

        //optionsBuilder.LogTo(str => Console.WriteLine(str), new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

        //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder.Properties<StarRating>().HaveConversion<string>();
        //configurationBuilder.Properties<string>().HaveColumnType("varchar(100)");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JacustranDbContext).Assembly);

        // Seed data for testing

        modelBuilder.Entity<Spot>().Property(s => s.Rating).HasConversion<string>().HasColumnType("nvarchar(20)");


        modelBuilder.Entity<City>().HasData(
                new City(Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    "Kyoto",
                    "Kyoto is the culural capital of japan",
                    "https://dummyimage.com/600x400/eee/aaa",
                     1_475_000,
                    true),
                new City(Guid.Parse("fdbead28-d754-4feb-8acd-c4f9ff13ba96"),
                    "Tokyo",
                    "Tokyo is a megacity",
                    "https://dummyimage.com/600x400/eee/aaa",
                    13_960_000,
                    true),
                new City(Guid.Parse("ac338e7a-d754-4feb-8acd-c4f9ff13ba96"),
                    "Osaka",
                    "Osaka lies in the kanto area",
                    "https://dummyimage.com/600x400/eee/aaa",
                    2_691_000,
                    true));



        modelBuilder.Entity<Spot>().HasData(
            new Spot(Guid.Parse("af871625-d754-4feb-8acd-c4f9ff13ba96"), "Kiyomizu", "An ancient Temple with a stunning View over Kyoto.", "https://dummyimage.com/600x400/eee/aaa", StarRating.FourStars)
            {
                TownId = Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
            },
            new Spot(Guid.Parse("9384adfa-d754-4feb-8acd-c4f9ff13ba96"), "Oyamazaki", "A Neighbourhood with a certain melancholic feel.", "https://dummyimage.com/600x400/eee/aaa", StarRating.TwoStars)
            {
                TownId = Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
            },
            new Spot(Guid.Parse("9287afff-d754-4feb-8acd-c4f9ff13ba96"), "Kinkakuji Temple", "Colorful and with antique wooden structures", "https://dummyimage.com/600x400/eee/aaa", StarRating.ThreeStars)
            {
                TownId = Guid.Parse("af1fd609-d754-4feb-8acd-c4f9ff13ba96"),
            },
            new Spot(Guid.Parse("8374adda-d754-4feb-8acd-c4f9ff13ba96"), "Umeda", "It´s a train station but also much more than that.", "https://dummyimage.com/600x400/eee/aaa", StarRating.FourStars)
            {
                TownId = Guid.Parse("ac338e7a-d754-4feb-8acd-c4f9ff13ba96"),
            }, 
            new Spot(Guid.Parse("8374a227-d754-4feb-8acd-c4f9ff13fa34"), "Ojiron-Onsen", "A place to take a relaxing hot bath.", "https://dummyimage.com/600x400/eee/aaa", StarRating.FiveStars)
            {
                TownId = Guid.Parse("ffd3d609-d754-4feb-8acd-c4f9ff13adf4"),
            });



        modelBuilder.Entity<Town>().HasData(
            new Town(Guid.Parse("ffd3d609-d754-4feb-8acd-c4f9ff13adf4"), "Ojiro", "Ojiro is mostly a mountainous area and prides itself as the homeland of Wagyu cattle.", "https://dummyimage.com/600x400/eee/aaa", 2200)
            {
                
            });

    }


    public override void Dispose()
    {
        //_writer.Dispose();
        base.Dispose();
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
