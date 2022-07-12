using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;

namespace Infra.Repositories;

public class CardRepository : ICardRepository
{
	private readonly AppDbContext _context;

	/// <summary>
	///     Context dependency injection
	/// </summary>
	/// <param name="context"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public CardRepository(AppDbContext context)
	{
		_context = context;
	}

	/// <summary>
	///		Get a card by CardNumber
	/// </summary>
	/// <param name="cardNumber"></param>
	/// <returns>Card</returns>
	public Card GetByNumber(string cardNumber)
	{
		return _context.Cards!
			.FirstOrDefault(p => p.Number == cardNumber)!;
	}

	/// <summary>
	///		Create a card
	/// </summary>
	/// <param name="card"></param>
	public void Post(Card card)
	{
		_context.Cards!.Add(card);

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
