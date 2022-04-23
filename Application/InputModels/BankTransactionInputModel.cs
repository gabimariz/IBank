using Domain.Enums;

namespace Application.InputModels;

public class BankTransactionInputModel
{
	public string? FullName { get; set; }

	public string? Cpf { get; set; }

  public double Money { get; set; }

	public TransactionType Type { get; set; }

	public string? Agency { get; set; }

	public string? Bill { get; set; }

	public Guid FromId { get; set; }
}
