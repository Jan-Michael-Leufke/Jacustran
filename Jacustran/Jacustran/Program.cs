global using Jacustran.Domain.Entity.Entities;
global using Jacustran.Domain.Entity.Shared;

using Jacustran.Client.Components.PageComponents;
using Jacustran.Components;
using Jacustran.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices();

app.ConfigurePipeline();

//await app.ResetDatabaseAsync();

app.Run();
