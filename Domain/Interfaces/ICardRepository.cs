using Domain.Entities;

namespace Domain.Interfaces;

public interface ICardRepository : IDisposable
{
	Card GetByNumber(string cardNumber);

	void Post(Card card);

	void Save();
}
