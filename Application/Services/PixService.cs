using Domain.Entities;
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

	public PixTransfer Transfer(double money, string toCpf, Guid fromId)
	{
		var fromUser = _appDbContext.Users!
			.Include(p => p.Account)
			.FirstOrDefault(p => p.Id == fromId);

		var fromMoney = fromUser!.Account!.Money = fromUser.Account.Money - money;

		if (fromMoney < 0 || money <= 0)
			throw new Exception();

		var toUser = _userRepository.GetByCpf(toCpf);

		_userRepository.Save();

		toUser.Account!.Money = toUser.Account.Money + money;

		_pixRepository.Transfer(money, toUser.Id, Guid.NewGuid());
		_pixRepository.Save();

		return new PixTransfer
		{
			Id = Guid.NewGuid(),
			Money = money,
			To = toUser.Id,
			From = Guid.NewGuid()
		};
	}
}
