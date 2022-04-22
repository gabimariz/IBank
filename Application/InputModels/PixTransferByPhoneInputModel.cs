using System.ComponentModel.DataAnnotations;

namespace Application.InputModels;

public class PixTransferByPhoneInputModel
{
	[Required(ErrorMessage = "Value is required")]
	[Range(0.1, Double.MaxValue, ErrorMessage = "Value cannot be less than zero!")]
	public double Money { get; set; }

	[Required(ErrorMessage = "Phone number is required")]
	public string? ToPhone { get; set; }

	[Required(ErrorMessage = "Id is required")]
	public Guid FromId { get; set; }
}
