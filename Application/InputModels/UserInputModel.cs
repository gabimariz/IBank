using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Application.InputModels;

public class UserInputModel
{
	[Required(ErrorMessage = "Name cannot be empty!")]
	public string? FullName { get; set; }

	[Required(ErrorMessage = "Cpf cannot be empty!")]
	public string? Cpf { get; set; }

	[Required(ErrorMessage = "PhoneNumber cannot be empty!")]
	public string? PhoneNumber { get; set; }

	[Required(ErrorMessage = "Email cannot be empty!")]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Account type cannot be empty!")]
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public AccountType AccountType { get; set; }

	public double Money { get; set; } = 0;

	[Required(ErrorMessage = "Password cannot be empty!")]
	public string? Password { get; set; }
}
