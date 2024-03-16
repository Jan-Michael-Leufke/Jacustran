global using Jacustran.Shared.Contracts;
global using Jacustran.Shared.Enumerations;
global using Jacustran.Shared.Exceptions;
global using Jacustran.Shared.Responses;
global using Jacustran.Domain.Categories;
global using Jacustran.Domain.Cities;
global using Jacustran.Domain.Products;
global using Jacustran.Domain.Spots;
global using Jacustran.Domain.Shared;

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
