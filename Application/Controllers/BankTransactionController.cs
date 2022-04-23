using Application.InputModels;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class BankTransactionController : ControllerBase
{
	private readonly IBankTransactionService<BankTransactionInputModel> _bankTransactionService;
	public BankTransactionController(IBankTransactionService<BankTransactionInputModel> bankTransactionService)
	{
		_bankTransactionService = bankTransactionService;
	}

	[HttpPost("Ted")]
	[Authorize]
	public ActionResult<BankTransaction> TransferByTed([FromBody] BankTransactionInputModel input)
	{
		try
		{
			return _bankTransactionService.TedTransfer(input);
		}
		catch (UserNotFoundException)
		{
			return NotFound("User not found!");
		}
		catch (WithoutMoneyException)
		{
			return UnprocessableEntity("Insufficient value!");
		}
	}
}
