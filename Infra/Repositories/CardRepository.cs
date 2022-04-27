using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;

namespace Infra.Repositories;

public class CardRepository : ICardRepository
{
	private readonly AppDbContext _appDbContext;

	public CardRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public Card GetByCardNumber(Guid userId)
	{
		var card = _appDbContext.Cards!.FirstOrDefault(p => p.UserId == userId);

		if (userId == card!.UserId)
			return card;

		return null!;
	}
	public void Insert(Card card)
	{
		_appDbContext.Cards!.Add(card);
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
