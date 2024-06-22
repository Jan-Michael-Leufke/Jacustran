using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

namespace Jacustran.Domain.Registrations;

public static class DomainServiceRegistrations
{
    public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(AssemblyReference.Get);

        return services;
    }
}
