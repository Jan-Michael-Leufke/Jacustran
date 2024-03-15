global using AutoMapper;
global using MediatR;
global using Jacustran.Domain.Entity.Entities;
global using Jacustran.Domain.Entity.Shared;
global using Jacustran.Application.Contracts.Persistence;
global using Jacustran.Domain.Responses;

using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;

namespace Jacustran.Application.Registrations;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        var currentAppDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddAutoMapper(currentAppDomainAssemblies);
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(currentAppDomainAssemblies));
        services.AddValidatorsFromAssemblies(currentAppDomainAssemblies);

        return services;
    }
}
