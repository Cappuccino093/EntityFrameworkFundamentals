using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfProject.Models;

public record Task
{
	[Key]
	public Guid Id { get; private init; } = Guid.NewGuid();

	[ForeignKey("Category")]
	public required Guid CategoryId { get; init; }

	[Required]
	[MaxLength(200)]
	public required string Title { get; init; }
	
	public required string Description { get; init; }
	public required Priority Priority { get; init; }
	public required DateTime CreatedAt { get; init; }

	public required virtual Category Category { get; init; }
}
