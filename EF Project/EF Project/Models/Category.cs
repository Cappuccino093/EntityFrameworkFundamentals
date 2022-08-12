using System.ComponentModel.DataAnnotations;

namespace EfProject.Models;

public record Category
{
	[Key]
	public Guid Id { get; private init; } = Guid.NewGuid();

	[Required]
	[MaxLength(150)]
	public required string Name { get; init; }

	public string? Description { get; init; }
	public int? Weight { get; init; }

	public virtual Task[]? Tasks { get; init; }
}
