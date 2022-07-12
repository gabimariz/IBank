using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Profile
{
	[Column(name: "id")]
	public Guid Id { get; set; }

	[Column(name: "name")]
	public string? Name { get; set; }

	[Column(name: "cpf")]
	public string? Cpf { get; set; }

	[Column(name: "phone_number")]
	public string? PhoneNumber { get; set; }

	[JsonIgnore]
	public virtual User? User { get; set; }

	[Column(name: "fk_user")]
	public Guid FkUser { get; set; }

	[Column(name: "bank_account")]
	public virtual BankAccount? BankAccount { get; set; }

	public virtual Card? Card { get; set; }

	[Column(name: "create_at")]
	public DateTime CreateAt { get; set; }

	[Column(name: "update_at")]
	public DateTime UpdateAt { get; set; }
}
