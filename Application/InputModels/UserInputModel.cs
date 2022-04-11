
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.InputModels;

public class UserInputModel
{
	[Required(ErrorMessage = "Name cannot be empty!")]
	public string? FullName { get; set; }

	[Required(ErrorMessage = "Cpf cannot be empty!")]
	public string? Cpf { get; set; }

	[Required(ErrorMessage = "Email cannot be empty!")]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Password cannot be empty!")]
	public string? Password { get; set; }
}
