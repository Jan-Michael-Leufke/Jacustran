global using Jacustran.Domain.Categories;
global using Jacustran.Domain.Cities;
global using Jacustran.Domain.Products;
global using Jacustran.Shared.Contracts;
global using Jacustran.Domain.Spots;
global using Jacustran.Domain.Shared;
global using Jacustran.Shared.Responses;

global using Jacustran.Persistence.DbContexts;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Jacustran.Persistence.Repositories;
using Jacustran.Persistence.Abstractions;

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
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
