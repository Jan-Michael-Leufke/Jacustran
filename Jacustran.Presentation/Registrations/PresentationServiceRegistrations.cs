global using Jacustran.Domain.Entity.Entities;
global using Jacustran.Domain.Entity.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Jacustran.Presentation.Registrations;

public static class PresentationServiceRegistrations
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }

}
