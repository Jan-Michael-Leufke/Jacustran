global using Jacustran.Domain.Entities;
global using Jacustran.Domain.Shared;

using Jacustran.Client.Components.PageComponents;
using Jacustran.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();
builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7248") });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup => 
{ 
    setup.SwaggerDoc("v1", new()  { Title = "Jacustran API", Version = "v1", Description = "Colletions of Endpoints for Jacustran related Data-Fetching used in the context of SPAs." });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(setup =>
{
    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Jacustran API V1");
    setup.RoutePrefix = "swagger";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Jacustran.Client._Imports).Assembly);


app.Run();
