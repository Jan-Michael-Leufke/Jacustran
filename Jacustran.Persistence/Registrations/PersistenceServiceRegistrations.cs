global using Jacustran.Domain.Categories;
global using Jacustran.Domain.City;
global using Jacustran.Domain.Products;
global using Jacustran.SharedKernel.Contracts;
global using Jacustran.Domain.Spots;
global using Jacustran.Domain.Shared;
global using Jacustran.SharedKernel.Responses;
global using Jacustran.SharedKernel.Abstractions.Entities;
global using Jacustran.SharedKernel.Abstractions;

global using Jacustran.Persistence.DbContexts;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Jacustran.Persistence.Repositories;
using Jacustran.Persistence.Abstractions;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Jacustran.SharedKernel.Interfaces.Persistence;

namespace Jacustran.Persistence.Registrations;

public static class PersistenceServiceRegistrations
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JacustranDbContext>(options =>
        {
            //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            var conStr = configuration.GetConnectionString("DefaultConnection");

            options.UseSqlServer(conStr)
            .EnableSensitiveDataLogging();
        });

        services.AddScoped(typeof(IAsyncRepository<,>), typeof(BaseRepository<,>));
        services.AddScoped(typeof(IAsyncReadRepository<,>), typeof(CachedRepository<,>));
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICityReadRepository, CityReadRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISpotRepository, SpotRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
