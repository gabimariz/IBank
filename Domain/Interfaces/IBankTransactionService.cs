using Domain.Models;

namespace Domain.Interfaces;

public interface IBankTransactionService
{
	void PostByEmail(TransactionByEmailInputModel model);

	void PostByCpf(TransactionByCpfInputModel model);

	void PostByPhoneNumber(TransactionByPhoneNumberInputModel model);

	void PostByTed(TransactionByTedAndDocInputModel model);

	void PostByDoc(TransactionByTedAndDocInputModel model);
}
