using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Account
{
	[Key]
	public Guid Id { get; set; }

	public string? Bill { get; set; }
	public string? Agency { get; set; }

	public double Money { get; set; }

	[ForeignKey("User")]
	public Guid UserId { get; set; }

	public virtual User? User { get; set; }
}
