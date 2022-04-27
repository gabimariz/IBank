using Domain.Entities;

namespace Domain.Interfaces;

public interface ICardService<in T>
{
	Card GetByCardNumber(T input);
	Card Create(Card card);
}
