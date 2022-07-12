using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces;

public interface ICardService
{
	Card GetByNumber(string cardNumber);

	void Post(CardInputModel card);
}
