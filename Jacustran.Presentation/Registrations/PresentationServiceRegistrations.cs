global using Jacustran.SharedKernel.Contracts;
global using Jacustran.Domain.Enumerations;
global using Jacustran.Domain.Exceptions;
global using Jacustran.SharedKernel.Responses;
global using Jacustran.Domain.Categories;
global using Jacustran.Domain.Cities;
global using Jacustran.Domain.Products;
global using Jacustran.Domain.Spots;
global using Jacustran.Domain.Shared;
global using Jacustran.Presentation.Abstractions;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.AspNetCore.Mvc;

global using AutoMapper;
global using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Jacustran.Presentation.Registrations;

public static class PresentationServiceRegistrations
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }

}
