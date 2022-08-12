using EfProject.Models;
using Microsoft.EntityFrameworkCore;
using Task = EfProject.Models.Task;

namespace EfProject;

public class EfProjectContext : DbContext
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Task> Tasks { get; set; }

	public EfProjectContext(DbContextOptions<EfProjectContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		Category[] categories =
		{
			new()
			{
				Name = "To-Do"
			},
			new()
			{
				Name = "Personal"
			}
		};

		Task[] tasks =
		{
			new()
			{
				Title = "Bills",
				CategoryId = categories[0].Id,
				Priority = Priority.High
			},
			new()
			{
				Title = "See Movie",
				CategoryId = categories[1].Id,
				Priority = Priority.Low
			}
		};

		_ = modelBuilder.Entity<Category>((category) => _ = category.HasData(categories));
		_ = modelBuilder.Entity<Task>((task) => _ = task.HasData(tasks));
	}
}
