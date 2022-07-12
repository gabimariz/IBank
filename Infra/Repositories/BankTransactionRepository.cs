using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;

namespace Infra.Repositories;

public class BankTransactionRepository : IBankTransactionRepository
{
	private readonly AppDbContext _context;

	/// <summary>
	///  Context dependency injection
	/// </summary>
	/// <param name="context"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public BankTransactionRepository(AppDbContext context)
	{
		_context = context;
	}

	/// <summary>
	///     Adds a new bank transactionto the database
	/// </summary>
	/// <param name="model"></param>
	public void Post(BankTransaction model)
	{
		_context.BankTransactions!.Add(model);

		Save();
	}

	public void Save()
	{
		_context.SaveChanges();
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
