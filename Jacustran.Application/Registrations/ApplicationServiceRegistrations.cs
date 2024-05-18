global using AutoMapper;
global using MediatR;
global using FluentValidation;

global using Jacustran.Domain.Products;
global using Jacustran.Domain.Categories;
global using Jacustran.Domain.Cities;
global using Jacustran.Domain.Spots;
global using Jacustran.Domain.Shared;

global using Jacustran.SharedKernel.Responses;
global using Jacustran.Domain.Exceptions;
global using Jacustran.SharedKernel.Contracts;
global using Jacustran.Domain.Enumerations;



global using Jacustran.SharedKernel.Abstractions.MediatR;
global using Jacustran.SharedKernel.Abstractions.Entities;
global using Jacustran.SharedKernel.Behaviours;
global using Jacustran.SharedKernel.Interfaces.MediatR;
global using Jacustran.SharedKernel.Abstractions;
global using Jacustran.Application.Abstractions.Api;




global using Microsoft.AspNetCore.JsonPatch;

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
