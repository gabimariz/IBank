using Application.InputModels;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CardController : ControllerBase
{
	private readonly ICardService<GetCardByUserIdInputModel> _cardService;

	public CardController(ICardService<GetCardByUserIdInputModel> cardService)
	{
		_cardService = cardService;
	}

	[HttpGet("{UserId}")]
	[Authorize]
	public ActionResult<Card> Create([FromRoute] GetCardByUserIdInputModel input)
	{

		try
		{
			return _cardService.GetByCardNumber(input);
		}
		catch (UnlinkedCardException)
		{
			return StatusCode(204, "no card linked to account!");
		}

	}

	[HttpPost]
	[Authorize]
	public ActionResult<Card> Create([FromBody] Card card)
	{

			return _cardService.Create(card);

	}
}
