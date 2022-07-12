using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Enums;

namespace Domain.Entities;

public class BankTransaction
{
	[Column(name: "id")]
	public Guid Id { get; set; }

	[Column(name: "money")]
	public decimal Money { get; set; }

	[Column(name: "to")]
	public Guid To { get; set; }

	[Column(name: "from")]
	public Guid From { get; set; }

	[Column(name: "type")]
	public TransactionType Type { get; set; }

	[Column(name: "create_at")]
	public DateTime CreateAt { get; set; }

	[Column(name: "update_at")]
	public DateTime UpdateAt { get; set; }
}
