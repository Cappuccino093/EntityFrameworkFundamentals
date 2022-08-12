using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EfProject.Models;

public record Category
{
	[Key]
	public Guid Id { get; private init; } = Guid.NewGuid();

	[Required]
	[MaxLength(150)]
	public required string Name { get; set; }

	public string? Description { get; set; }
	public int? Weight { get; set; }

	[NotMapped]
	[JsonIgnore]
	public virtual Task[]? Tasks { get; set; }
}
