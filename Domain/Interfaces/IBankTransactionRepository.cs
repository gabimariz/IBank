using Domain.Enums;

namespace Domain.Interfaces;

public interface IBankTransactionRepository : IDisposable
{
	void Transfer(double money, Guid to, Guid from, TransactionType type);

	void Save();
}
