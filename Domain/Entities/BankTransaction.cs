using Domain.Enums;

namespace Domain.Entities;

public class BankTransaction
{
	public Guid Id { get; set; }

	public double Money { get; set; }

	public Guid To { get; set; }

	public Guid From { get; set; }

	public TransactionType TransactionType { get; set; }
}
