using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces;

public interface IBankTransactionRepository : IDisposable
{
	void Post(BankTransaction model);

	void Save();
}
