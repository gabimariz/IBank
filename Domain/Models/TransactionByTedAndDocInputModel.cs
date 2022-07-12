using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Domain.Models;

public class TransactionByTedAndDocInputModel
{
	[Required]
	public string? Name { get; set; }

	[Required]
	public string? Cpf { get; set; }

	[Required]
	public decimal Money { get; set; }

	[Required]
	public string? Agency { get; set; }

	[Required]
	public string? Bill { get; set; }

	[Required]
	public Guid FromUserId { get; set; }
}
