using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Card
{
	[Key]
	public Guid Id { get; set; }

	public string? Number { get; set; }

	public int Cvv { get; set; }

	public string? Password { get; set; }

	[ForeignKey("User")]
	public Guid UserId { get; set; }

	public virtual User? User { get; set; }

	public CardType Type { get; set; }

	public DateTime Validity { get; set; }
}
