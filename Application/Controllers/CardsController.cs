using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v2/card")]
public class CardsController : ControllerBase
{
	private readonly ICardService _service;

	/// <summary>
	/// Service dependency injection
	/// </summary>
	/// <param name="service"></param>
	public CardsController(ICardService service)
	{
		_service = service;
	}

	/// <summary>
	///		Get a card by number
	/// </summary>
	/// <param name="cardNumber"></param>
	/// <response code="200">OK</response
	/// <response code="204">No Content</response>
	/// <returns>Card</returns>
	[HttpGet("{cardNumber}")]
	public IActionResult GetByNumber(string cardNumber)
	{
		try
		{
			return Ok(_service.GetByNumber(cardNumber));
		}
		catch (NotFoundException)
		{
			return NoContent();
		}
	}

	/// <summary>
	///		Create a new card
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response
	/// <response code="204">No Content</response>
	/// <returns></returns>
	[HttpPost]
	public IActionResult Post(CardInputModel model)
	{
		try
		{
			_service.Post(model);

			return Ok("Card created!");
		}
		catch (NotFoundException)
		{
			return NoContent();
		}
	}
}
