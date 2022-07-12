using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Domain.Models;

public class UserInputModel
{

	[Required(ErrorMessage = "Email cannot be empty!")]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Password cannot be empty!")]
	public string? Password { get; set; }

	[Required(ErrorMessage = "Name cannot be empty!")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "CPF cannot be empty@")]
	public string? Cpf { get; set; }

	[Required(ErrorMessage = "Phone number cannot be empty!")]
	public string? PhoneNumber { get; set; }

	[Required(ErrorMessage = "Account type cannot be empty!")]
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public AccountType AccountType { get; set; }

	public DateTime CreateAt { get; set; } = DateTime.Now;

	public DateTime UpdateAt { get; set; } = DateTime.Now;
}
