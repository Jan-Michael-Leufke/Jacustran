using FluentValidation.AspNetCore;
using Jacustran.Application.Contracts.Application.MediatR;
using Jacustran.Application.Registrations;
using Jacustran.Components;
using Jacustran.Middleware.ExceptionsHandling;
using Jacustran.Persistence.DbContexts;
using Jacustran.Persistence.Registrations;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Xml;

namespace Jacustran.Extensions;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder) 
    {
        builder.Host.UseSerilog((context, services, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration)
                         .ReadFrom.Services(services)
                         .Enrich.FromLogContext()
                         .WriteTo.Console();
        }, preserveStaticLogger : true, writeToProviders : false);

        builder.Services.RegisterApplicationServices()
                        .RegisterPersistenceServices(builder.Configuration);


        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddControllers(configure =>
        {
            configure.ReturnHttpNotAcceptable = true;
            configure.InputFormatters.Add(new XmlSerializerInputFormatter(new() { AllowEmptyInputInBodyModelBinding = true }));
            configure.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter(new XmlWriterSettings() { }));
        })
       .AddApplicationPart(Presentation.Registrations.AssemblyReference.Get);


        //builder.Services.AddFluentValidationAutoValidation(c => c.DisableDataAnnotationsValidation = true);
                        //.AddFluentValidationClientsideAdapters();

        //builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

        builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7248") });
        builder.Services.AddHttpContextAccessor();


        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        builder.Services.AddProblemDetails(configure =>
        {
            //configure.CustomizeProblemDetails = context =>
            //{
            //    context.ProblemDetails.Extensions.Add("additional entry", "some info from customized Problemdetails");
            //    context.ProblemDetails.Status = 777;
            //};
        });

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
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new() { Title = "Jacustran API", Version = "v1", Description = "Colletions of Endpoints for Jacustran related Data-Fetching used in the context of SPAs." });
        });

        
        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)

    {
        app.UseCors("blazor");  

        app.UseSerilogRequestLogging();

        app.UseSwagger();
        app.UseSwaggerUI(setup =>
        {
            setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Jacustran API V1");
            setup.RoutePrefix = "swagger";

        });

        if (app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler();
            //app.UseWebAssemblyDebugging();
            //app.UseDeveloperExceptionPage();
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
