using EfProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<EfProjectContext>((options) => _ = options.UseInMemoryDatabase("EF Project"));
builder.Services.AddSqlServer<EfProjectContext>(builder.Configuration.GetConnectionString("EF Project")!);

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/ef-project", ([FromServices] EfProjectContext efProjectContext) =>
{
	_ = efProjectContext.Database.EnsureCreated();
	return Results.Ok($"Database in memory: {efProjectContext.Database.IsInMemory()}");
});

app.Run();
