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

	public void TransferByCpf(double money, Guid to, Guid from)
	{
		_appDbContext.PixTransfers!.Add(new PixTransfer
		{
			Money = money,
			To = to,
			From = from
		});
	}

	public void Save()
	{
		_appDbContext.SaveChanges();
	}
}
