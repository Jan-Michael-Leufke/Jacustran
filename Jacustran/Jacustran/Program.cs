using Jacustran.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices();

app.ConfigurePipeline();

//await app.ResetDatabaseAsync();





app.Run();
