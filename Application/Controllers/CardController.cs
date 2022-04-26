using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CardController : ControllerBase
{
	private readonly ICardService _cardService;

	public CardController(ICardService cardService)
	{
		_cardService = cardService;
	}

	[HttpPost]
	public ActionResult<Card> Create([FromBody] Card card)
	{

			return _cardService.Create(card);

	}
}
