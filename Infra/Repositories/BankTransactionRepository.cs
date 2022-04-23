using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infra.Data;

namespace Infra.Repositories;

public class BankTransactionRepository : IBankTransactionRepository
{
	private readonly AppDbContext _appDbContext;

	public BankTransactionRepository(AppDbContext appContext)
	{
		_appDbContext = appContext;
	}

	public void Transfer(double money, Guid to, Guid from, TransactionType type)
	{
		_appDbContext.BankTransactions!.Add(new BankTransaction
		{
			Id = Guid.NewGuid(),
			Money = money,
			To = to,
			From = from,
			TransactionType = type
		});
	}

	public void Save()
	{
		_appDbContext.SaveChanges();
	}

	public void Dispose()
	{
		_appDbContext.Dispose();
	}
}
