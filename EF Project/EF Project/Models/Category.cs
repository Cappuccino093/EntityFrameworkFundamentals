using System.ComponentModel.DataAnnotations;

namespace EfProject.Models;

public record Category
{
	[Key]
	public Guid Id { get; private init; } = Guid.NewGuid();

	[Required]
	[MaxLength(150)]
	public required string Name { get; init; }

	public required string Description { get; init; }

	public required virtual Task[] Tasks { get; init; }
}
