using EfProject.Models;
using Microsoft.EntityFrameworkCore;
using Task = EfProject.Models.Task;

namespace EfProject;

public class EfProjectContext : DbContext
{
	public DbSet<Category> Categories { get; set; }
	public DbSet<Task> Tasks { get; set; }

	public EfProjectContext(DbContextOptions<EfProjectContext> options) : base(options) { }
}
