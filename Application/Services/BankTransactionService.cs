using Application.InputModels;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infra.Repositories;

namespace Application.Services;

public class BankTransactionService: IBankTransactionService<BankTransactionInputModel>
{
	private readonly IUserRepository _userRepository;
	private readonly IBankTransactionRepository _transactionRepository;

	public BankTransactionService(IUserRepository userRepository, IBankTransactionRepository transactionRepository)
	{
		_userRepository = userRepository;
		_transactionRepository = transactionRepository;
	}

	public BankTransaction TedTransfer(BankTransactionInputModel transaction)
	{
		var fromUser = _userRepository.GetById(transaction.FromId!);

		if (fromUser == null) throw new UserNotFoundException();

		if (fromUser!.Account!.Money <= 0) throw new WithoutMoneyException();

		fromUser.Account!.Money -= transaction.Money;

		var toUser = _userRepository.GetByCpf(transaction.Cpf!);

		toUser.Account!.Money += transaction.Money;

		_transactionRepository.Transfer(transaction.Money, toUser.Id, fromUser.Id, transaction.Type);
		_transactionRepository.Save();

		return new BankTransaction
		{
			Id = Guid.NewGuid(),
			Money = transaction.Money,
			To = toUser.Id,
			From = fromUser.Id,
			TransactionType = transaction.Type
		};
	}
}
