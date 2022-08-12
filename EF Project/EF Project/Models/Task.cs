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
	
	public string? Description { get; init; }
	public Priority? Priority { get; init; }
	public DateTime CreatedAt { get; private init; } = DateTime.Now;

	public virtual Category? Category { get; init; }
}
