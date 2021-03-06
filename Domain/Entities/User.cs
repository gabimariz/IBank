using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Domain.Entities;

public class User
{
	[Column(name: "id")]
	public Guid Id { get; set; }

	[Column(name: "email")]
	public string? Email { get; set; }

	[Column(name: "password")]
	public string? Password { get; set; }

	public virtual Profile? Profile { get; set; }

	[Column(name: "role")]
	public Roles Role { get; set; }

	[Column(name: "create_at")]
	public DateTime CreateAt { get; set; }

	[Column(name: "update_at")]
	public DateTime UpdateAt { get; set; }
}
