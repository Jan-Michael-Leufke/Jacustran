global using Jacustran.Domain.Entities;
global using Jacustran.Domain.Shared;
global using Jacustran.Application.Contracts.Persistence;
global using Jacustran.Persistence.DbContexts;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Jacustran.Persistence.Repositories;

namespace Jacustran.Persistence.Registrations;

public static class PersistenceServiceRegistrations
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JacustranDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISpotRepository, SpotRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
