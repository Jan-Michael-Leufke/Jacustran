using Jacustran.Extensions;
using Jacustran.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices();

app.ConfigurePipeline();

await app.ResetDatabaseAsync();


app.Map("/debug", (JacustranDbContext context) => 
{
    int sql = 0;

    var res2 = context.Spots.FromSql($"debugtest {sql}").ToList();

    return TypedResults.Ok(res2);

    
    //var res = await context.Database.SqlQuery<int>($"select population from town where discriminator = 'City'").ToListAsync();
    //return TypedResults.Ok(res);
});



app.Run();
    