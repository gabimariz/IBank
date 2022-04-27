using Application.InputModels;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Application.Services;

public class CardService : ICardService<GetCardByUserIdInputModel>
{
	private readonly ICardRepository _cardRepository;

	public CardService(ICardRepository cardRepository)
	{
		_cardRepository = cardRepository;
	}

	public Card GetByCardNumber(GetCardByUserIdInputModel input)
	{
		var card = _cardRepository.GetByCardNumber(input.UserId);

		if (card == null)
			throw new UnlinkedCardException();

		return card;
	}

	public Card Create(Card card)
	{
		var newCard = new Card
		{
			Id = Guid.NewGuid(),
			Number = GenerateCard.New(),
			Cvv = int.Parse(GenerateCard.Cvv()),
			Password = BCrypt.Net.BCrypt.HashPassword(card.Password),
			UserId = card.UserId,
			Type = card.Type,
			Validity = DateTime.Now
		};

		_cardRepository.Insert(newCard);
		_cardRepository.Save();

		return newCard;
	}
}
