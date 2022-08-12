using EfProject;
using EfProject.Models;
using Task = EfProject.Models.Task;
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

app.MapGet("/api/tasks/", async ([FromServices] EfProjectContext efProjectContext) => Results.Ok(await efProjectContext.Tasks.ToArrayAsync()));

app.MapPost("/api/tasks/", async ([FromServices] EfProjectContext efProjectContext, [FromBody] Task task) =>
{
	_ = await efProjectContext.Tasks.AddAsync(task);
	_ = await efProjectContext.SaveChangesAsync();
	return Results.Ok(task);
});

app.MapPut("/api/tasks/{guid}", async ([FromServices] EfProjectContext efProjectContext, [FromBody] Task task, [FromRoute] Guid guid) =>
{
	Task? previousTask = await efProjectContext.Tasks.FindAsync(guid);

	if (previousTask is null)
		return Results.NotFound();

	previousTask.Title = task.Title;
	previousTask.Description = task.Description;
	previousTask.CategoryId = task.CategoryId;
	previousTask.Priority = task.Priority;

	_ = await efProjectContext.SaveChangesAsync();

	return Results.Ok(previousTask);
});

app.MapDelete("/api/tasks/{guid}", async ([FromServices] EfProjectContext efProjectContext, [FromRoute] Guid guid) =>
{
	Task? task = await efProjectContext.Tasks.FindAsync(guid);

	if (task is null)
		return Results.NotFound();

	_ = efProjectContext.Tasks.Remove(task);
	_ = await efProjectContext.SaveChangesAsync();

	return Results.Ok();
});

app.Run();
