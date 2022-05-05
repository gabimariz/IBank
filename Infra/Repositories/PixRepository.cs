using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;

namespace Infra.Repositories;

public class PixRepository : IPixRepository
{
	private readonly AppDbContext _appDbContext;

	public PixRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public void Transfer(double money, Guid to, Guid from)
	{
		_appDbContext.PixTransfers!.Add(new PixTransfer
		{
			Money = money,
			To = to,
			From = from
		});
	}

	public PixTransfer TransferById(Guid id)
	{
		return _appDbContext.PixTransfers!
			.FirstOrDefault(p => p.Id == id)!;
	}

	public void Save()
	{
		_appDbContext.SaveChanges();
	}
}
