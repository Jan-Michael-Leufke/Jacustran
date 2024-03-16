global using AutoMapper;
global using MediatR;
global using FluentValidation;

global using Jacustran.Domain.Products;
global using Jacustran.Domain.Categories;
global using Jacustran.Domain.Cities;
global using Jacustran.Domain.Spots;
global using Jacustran.Domain.Shared;

global using Jacustran.Shared.Responses;
global using Jacustran.Shared.Exceptions;
global using Jacustran.Shared.Contracts;
global using Jacustran.Shared.Enumerations;

global using Jacustran.Application.Contracts.Application.MediatR;


using Microsoft.Extensions.DependencyInjection;
using System.Security;

namespace Jacustran.Application.Registrations;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        var currentAppDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddAutoMapper(currentAppDomainAssemblies);
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(currentAppDomainAssemblies);
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(AssemblyReference.Get);

        return services;
    }
}
