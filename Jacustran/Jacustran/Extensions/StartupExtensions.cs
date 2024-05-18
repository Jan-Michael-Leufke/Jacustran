using FluentValidation.AspNetCore;
using Jacustran.Application.Registrations;
using Jacustran.Components;
using Jacustran.Middleware.ExceptionsHandling;
using Jacustran.Persistence.DbContexts;
using Jacustran.Persistence.Registrations;
using Jacustran.SharedKernel.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.Xml;

namespace Jacustran.Extensions;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        //RegisterSerilog(builder);

        builder.Services.RegisterApplicationServices()
                        .RegisterPersistenceServices(builder.Configuration);

        RegisterBlazorServices(builder);

        RegisterMvcServices(builder);

        RegisterFluentValidationServices(builder);

        RegisterTransientServices(builder);

        RegisterScopedServices(builder);

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        RegisterProblemDetails(builder);

        RegisterCorsServices(builder);

        RegisterSwaggerServices(builder);

        return builder.Build();
    }


    private static void RegisterTransientServices(WebApplicationBuilder builder)
    {
        //builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

    }

    private static void RegisterScopedServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7248") });

    }

    private static void RegisterBlazorServices(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();
    }

    private static void RegisterSerilog(WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, services, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration)
                         .ReadFrom.Services(services)
                         .Enrich.FromLogContext()
                         .WriteTo.Console();
        }, preserveStaticLogger: true, writeToProviders: false);
    }

    private static void RegisterFluentValidationServices(WebApplicationBuilder builder)
    {
        //builder.Services.AddFluentValidationAutoValidation(c => c.DisableDataAnnotationsValidation = true);
        //.AddFluentValidationClientsideAdapters();
    }

    private static void RegisterSwaggerServices(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new() { Title = "Jacustran API", Version = "v1", Description = "Colletions of Endpoints for Jacustran related Data-Fetching used in the context of SPAs." });
        });
    }

    private static void RegisterCorsServices(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(setup =>
        {
            setup.AddPolicy("blazor", policy =>
            {
                policy.WithOrigins(builder.Configuration["ApiUrl"] ?? "https://localhost:7248")
                      .AllowAnyMethod().SetIsOriginAllowed(policy => true)
                      .AllowAnyHeader()
                      .AllowCredentials();
            });

            setup.AddPolicy("access", policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });
    }

    private static void RegisterMvcServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(configure =>
        {
            configure.ReturnHttpNotAcceptable = true;
            //configure.InputFormatters.Add(new XmlSerializerInputFormatter(new() { AllowEmptyInputInBodyModelBinding = true }));
            //configure.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter(new XmlWriterSettings() { }));
        })
       .AddApplicationPart(Presentation.Registrations.AssemblyReference.Get)
       .AddNewtonsoftJson(setup =>
       {
           setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
           setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
       })
       .AddXmlDataContractSerializerFormatters();
    }

    private static void RegisterProblemDetails(WebApplicationBuilder builder)
    {
        builder.Services.AddProblemDetails(configure =>
        {
            configure.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions.Add("additional entry", "some info from customized Problemdetails");
            };
        });
    }




    public static WebApplication ConfigurePipeline(this WebApplication app)

    {
        app.UseCors("blazor");  

        //app.UseSerilogRequestLogging();

        app.UseSwagger();
        app.UseSwaggerUI(setup =>
        {
            setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Jacustran API V1");
            setup.RoutePrefix = "swagger";

        });

        if (app.Environment.IsDevelopment())
        {
            //app.UseExceptionHandler();
            //app.UseWebAssemblyDebugging();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("An Unexpected Error occured, handled from StartUp Exceptionhandler Delegate");
                });
            });


            //app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();


        //app.UseMiddleware<CustomExceptionHandlingMiddleware>();

        app.UseStaticFiles();
        app.UseRouting();
        //app.UseAuthentication();
        //app.UseAuthorization();
        app.UseAntiforgery();
        app.MapControllers();
        
        

        app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode()
           .AddInteractiveWebAssemblyRenderMode()
           .AddAdditionalAssemblies(typeof(Jacustran.Client._Imports).Assembly);


        return app;
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        try
        {
            var context = scope.ServiceProvider.GetRequiredService<JacustranDbContext>();

            if (context is not null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
              //await context.Database.EnsureCreatedAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }

    }
}
