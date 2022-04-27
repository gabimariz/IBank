using Domain.Entities;

namespace Domain.Interfaces;

public interface ICardRepository : IDisposable
{
	Card GetByCardNumber(Guid userId);
	void Insert(Card card);

	void Save();
}
