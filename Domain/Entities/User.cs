using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities;

public class User
{
	public Guid Id { get; set; }

	public string? FullName { get; set; }

	public string? Cpf { get; set; }

	public string? PhoneNumber { get; set; }

	public virtual Account? Account { get; set; }

	public string? Email { get; set; }

	[JsonIgnore]
	public string? Password { get; set; }

	public Roles Role { get; set; }
}
