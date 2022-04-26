using Domain.Entities;

namespace Domain.Interfaces;

public interface ICardRepository : IDisposable
{
	void Insert(Card card);

	void Save();
}
