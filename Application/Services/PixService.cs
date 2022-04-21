using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class PixService : IPixService
{

	private readonly AppDbContext _appDbContext;
	private readonly IUserRepository _userRepository;
	private readonly IPixRepository _pixRepository;

	public PixService(
		AppDbContext appDbContext,
		IUserRepository userRepository,
		IPixRepository pixRepository)
	{
		_appDbContext = appDbContext;
		_userRepository = userRepository;
		_pixRepository = pixRepository;
	}

	public PixTransfer TransferByCpf(double money, string toCpf, Guid fromId)
	{
		var fromUser = _appDbContext.Users!
			.Include(p => p.Account)
			.FirstOrDefault(p => p.Id == fromId);

		if (fromUser!.Account!.Money <= 0)
			throw new WithoutMoneyException();

		fromUser.Account!.Money -= money;

		var toUser = _userRepository.GetByCpf(toCpf);

		_userRepository.Save();

		toUser.Account!.Money += money;

		_pixRepository.TransferByCpf(money, toUser.Id, fromId);
		_pixRepository.Save();

		return new PixTransfer
		{
			Id = Guid.NewGuid(),
			Money = money,
			To = toUser.Id,
			From = fromId
		};
	}
}
