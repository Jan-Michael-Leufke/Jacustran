global using Jacustran.Domain.Entities;
global using Jacustran.Domain.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Jacustran.Presentation.Registrations;

public static class PresentationServiceRegistrations
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }

}
