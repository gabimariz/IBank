using Domain.Entities;

namespace Domain.Interfaces;

public interface IBankTransactionService<in T>
{
	BankTransaction TedTransfer(T transaction);

	//BankTransaction DocTransfer<T>(T transaction);
}
