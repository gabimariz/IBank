using System.ComponentModel.DataAnnotations;

namespace Application.InputModels;

public class GetCardByUserIdInputModel
{
	[Required(ErrorMessage = "user id required!")]
	public Guid UserId { get; set; }
}
