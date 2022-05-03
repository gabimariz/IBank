using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities;

public class Card
{
	[Key]
	[JsonIgnore]
	public Guid Id { get; set; }

	public string? Number { get; set; }

	public int Cvv { get; set; }

	public string? Password { get; set; }

	[ForeignKey("User")]
	public Guid UserId { get; set; }

	[JsonIgnore]
	public virtual User? User { get; set; }

	public CardType Type { get; set; }

	[JsonIgnore]
	public DateTime Validity { get; set; }

	public DateTime CreateAt { get; set; } = DateTime.Now;
}
