using System.ComponentModel.DataAnnotations;

namespace Application.InputModels;

public class SignInInputModel
{
	[Required(ErrorMessage = "Email is required")]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Password is required")]
	public string? Password { get; set; }
}
