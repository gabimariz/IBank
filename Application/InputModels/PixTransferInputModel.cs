using System.ComponentModel.DataAnnotations;

namespace Application.InputModels;

public class PixTransferInputModel
{
	[Required(ErrorMessage = "Value is required")]
	public double Money { get; set; }

	[Required(ErrorMessage = "Cpf is required")]
	public string? ToCpf { get; set; }

	[Required(ErrorMessage = "Id is required")]
	public Guid FromId { get; set; }
}
