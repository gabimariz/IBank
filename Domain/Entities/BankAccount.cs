using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Domain.Entities;

public class BankAccount
{
	[Column(name: "id")]
	public Guid Id { get; set; }

	[Column(name: "bill")]
	public string? Bill { get; set; }

	[Column(name: "agency")]
	public string? Agency { get; set; }

	[Column(name: "money")]
	public decimal Money { get; set; }

	[JsonIgnore]
	public virtual Profile? Profile { get; set; }

	[Column(name: "fk_profile")]
	public Guid FkProfile { get; set; }

	[Column(name: "type")]
	public AccountType Type { get; set; }

	[Column(name: "create_at")]
	public DateTime CreateAt { get; set; }

	[Column(name: "update_at")]
	public DateTime UpdateAt { get; set; }
}
