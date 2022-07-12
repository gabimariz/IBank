using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Utils;

namespace Application.Services;

public class CardService : ICardService
{
	private readonly ICardRepository _card;
	private readonly IUserRepository _user;

	/// <summary>
	///		Repository dependency injection
	/// </summary>
	/// <param name="card"></param>
	/// <param name="user"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public CardService(ICardRepository card, IUserRepository user)
	{
		_card = card;
		_user = user;
	}

	/// <summary>
	///		Get card by number
	/// </summary>
	/// <param name="cardNumber"></param>
	/// <returns></returns>
	/// <exception cref="NotFoundException"></exception>
	public Card GetByNumber(string cardNumber)
	{
		var card = _card.GetByNumber(cardNumber);

		if (card == null)
			throw new NotFoundException();

		return card;
	}

	/// <summary>
	///	Create a new Card
	/// </summary>
	/// <param name="model"></param>
	public void Post(CardInputModel model)
	{
		var user = _user.GetByProfileId(model.ProfileId);

		var date = DateTime.Now;

		if (user == null)
			throw new NotFoundException();

		_card.Post(new Card
		{
			Id = Guid.NewGuid(),
			Number = GenerateCard.New(),
			Cvv = GenerateCard.Cvv(),
			Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
			FkProfile = model.ProfileId,
			Type = CardType.Debit,
			Validity = date.AddYears(8),
			CreateAt = date,
			UpdateAt = date
		});
	}
}
