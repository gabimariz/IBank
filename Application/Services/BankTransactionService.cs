using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BankTransactionService : IBankTransactionService
{
	private readonly IBankTransactionRepository _bankTransaction;
	private readonly IUserRepository _user;

	/// <summary>
	///		BankTransaction and User repository dependency injection
	/// </summary>
	/// <param name="bankTransaction"></param>
	/// <param name="user"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public BankTransactionService(IBankTransactionRepository bankTransaction, IUserRepository user)
	{
		_bankTransaction = bankTransaction;
		_user = user;
	}

	/// <summary>
	///		Adds a new bank transaction by PIX Email
	/// </summary>
	/// <param name="model"></param>
	/// <exception cref="UserNotFoundException"></exception>
	/// <exception cref="WithoutMoneyException"></exception>
	public void PostByEmail(TransactionByEmailInputModel model)
	{
		var fromUser = _user.GetById(model.FromUserId);
		var toUser = _user.GetByEmail(model.Email!);

		if(fromUser == null || toUser == null)
			throw new UserNotFoundException();

		if(fromUser.Profile!.BankAccount!.Money <= 0)
			throw new WithoutMoneyException();

		fromUser.Profile!.BankAccount!.Money -= model.Money;
		toUser.Profile!.BankAccount!.Money += model.Money;

		_bankTransaction.Post(new BankTransaction
		{
			Id = Guid.NewGuid(),
			Money = model.Money,
			To = toUser.Id,
			From = fromUser.Id,
			Type = model.Type,
			CreateAt = DateTime.Now,
			UpdateAt = DateTime.Now
		});
	}

	/// <summary>
	///		Adds a new bank transaction by PIX CPF
	/// </summary>
	/// <param name="model"></param>
	/// <exception cref="UserNotFoundException"></exception>
	/// <exception cref="WithoutMoneyException"></exception>
	public void PostByCpf(TransactionByCpfInputModel model)
	{
		var fromUser = _user.GetById(model.FromUserId);
		var toUser = _user.GetByCpf(model.Cpf!);

		if(fromUser == null || toUser == null)
            throw new UserNotFoundException();

		if(fromUser.Profile!.BankAccount!.Money <= 0)
			throw new WithoutMoneyException();

		fromUser.Profile!.BankAccount!.Money -= model.Money;
		toUser.Profile!.BankAccount!.Money += model.Money;

		_user.Save();

		_bankTransaction.Post(new BankTransaction
		{
			Id = Guid.NewGuid(),
			Money = model.Money,
			To = toUser.Id,
			From = fromUser.Id,
			Type = model.Type,
			CreateAt = DateTime.Now,
			UpdateAt = DateTime.Now
		});
    }

	/// <summary>
	///		Adds a new bank transaction by PIX PhoneNumber
	/// </summary>
	/// <param name="model"></param>
	/// <exception cref="UserNotFoundException"></exception>
	/// <exception cref="WithoutMoneyException"></exception>
	public void PostByPhoneNumber(TransactionByPhoneNumberInputModel model)
	{
		var fromUser = _user.GetById(model.FromUserId);
		var toUser = _user.GetByPhoneNumber(model.PhoneNumber!);

		if(fromUser == null || toUser == null)
			throw new UserNotFoundException();

		if(fromUser.Profile!.BankAccount!.Money <= 0)
			throw new WithoutMoneyException();

		fromUser.Profile!.BankAccount!.Money -= model.Money;
		toUser.Profile!.BankAccount!.Money += model.Money;

		_bankTransaction.Post(new BankTransaction
		{
			Id = Guid.NewGuid(),
			Money = model.Money,
			To = toUser.Id,
			From = fromUser.Id,
			Type = model.Type,
			CreateAt = DateTime.Now,
			UpdateAt = DateTime.Now
		});
	}

	/// <summary>
	///		Adds a new bank transaction by TED
	/// </summary>
	/// <param name="model"></param>
	/// <exception cref="UserNotFoundException"></exception>
	/// <exception cref="WithoutMoneyException"></exception>
	/// <exception cref="ManyDifferentException"></exception>
	public void PostByTed(TransactionByTedAndDocInputModel model)
	{
		var fromUser = _user.GetById(model.FromUserId);
		var toUser = _user.GetByCpf(model.Cpf!);

		if(DateTime.Now.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
			throw new WeekendException();

		if(DateTime.Now.Hour >= 17) throw new OvertimeException();

		if(fromUser == null || toUser == null)
			throw new UserNotFoundException();

		if(fromUser.Profile!.BankAccount!.Money <= 0)
			throw new WithoutMoneyException();

		if(toUser.Profile!.Name != model.Name
		   && toUser.Profile!.BankAccount!.Agency != model.Agency
		   && toUser.Profile!.BankAccount!.Bill != model.Bill)
			throw new ManyDifferentException();

		fromUser.Profile!.BankAccount!.Money -= model.Money;
		toUser.Profile!.BankAccount!.Money += model.Money;

		_user.Save();

		_bankTransaction.Post(new BankTransaction
		{
			Id = Guid.NewGuid(),
			Money = model.Money,
			To = toUser.Id,
			From = fromUser.Id,
			Type = TransactionType.Ted,
			CreateAt = DateTime.Now,
			UpdateAt = DateTime.Now
		});
	}

	/// <summary>
	///		Adds anew bank transaction by DOC
	/// </summary>
	/// <param name="model"></param>
	/// <exception cref="WeekendException"></exception>
	/// <exception cref="OvertimeException"></exception>
	/// <exception cref="UserNotFoundException"></exception>
	/// <exception cref="WithoutMoneyException"></exception>
	/// <exception cref="ManyDifferentException"></exception>
	public void PostByDoc(TransactionByTedAndDocInputModel model)
	{
		if (model.Money > 4999)
			throw new LimitExceededException();

		var fromUser = _user.GetById(model.FromUserId);
		var toUser = _user.GetByCpf(model.Cpf!);

		if(DateTime.Now.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
			throw new WeekendException();

		if(DateTime.Now.Hour >= 22) throw new OvertimeException();

		if(fromUser is null || toUser is null)
			throw new UserNotFoundException();

		if(fromUser.Profile!.BankAccount!.Money <= 0)
			throw new WithoutMoneyException();

		if(toUser.Profile!.Name != model.Name
		   && toUser.Profile!.BankAccount!.Agency != model.Agency
		   && toUser.Profile!.BankAccount!.Bill != model.Bill)
			throw new ManyDifferentException();

		fromUser.Profile!.BankAccount!.Money -= model.Money;
		toUser.Profile!.BankAccount!.Money += model.Money;

		_user.Save();

		_bankTransaction.Post(new BankTransaction
		{
			Id = Guid.NewGuid(),
			Money = model.Money,
			To = toUser.Id,
			From = fromUser.Id,
			Type = TransactionType.Doc,
			CreateAt = DateTime.Now,
			UpdateAt = DateTime.Now
		});
	}
}
