using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EfProject.Models;

public record Task
{
	[Key]
	public Guid Id { get; private init; } = Guid.NewGuid();

	[ForeignKey("Category")]
	public required Guid CategoryId { get; set; }

	[Required]
	[MaxLength(200)]
	public required string Title { get; set; }

	public string? Description { get; set; }
	public Priority? Priority { get; set; }
	public DateTime CreatedAt { get; private init; } = DateTime.Now;

	[NotMapped]
	[JsonIgnore]
	public virtual Category? Category { get; set; }
}
