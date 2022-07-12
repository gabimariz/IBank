using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Domain.Models;

public class TransactionByCpfInputModel
{
	[Required]
	public decimal Money { get; set; }

	[Required]
	public Guid FromUserId { get; set; }

	[Required]
	public string? Cpf { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public TransactionType Type { get; set; }
}
