global using AutoMapper;
global using MediatR;
global using Jacustran.Domain.Entities;
global using Jacustran.Domain.Shared;
global using Jacustran.Application.Contracts.Persistence;

using Microsoft.Extensions.DependencyInjection;

namespace Jacustran.Application.Registrations;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {

        var result = (AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(result);
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        return services;
    }
}
