using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v2")]
public class BankTransactionsController : ControllerBase
{
	private readonly IBankTransactionService _service;

	/// <summary>
	///     Service dependency injection
	/// </summary>
	/// <param name="service"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public BankTransactionsController(IBankTransactionService service)
	{
		_service = service;
	}

	/// <summary>
	///     Transfer money by EMAIL
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <response code="400">Bad Request</response>
	/// <returns>Money Transferred!</returns>
	[HttpPost("pix/email")]
	public IActionResult PostByEmail(TransactionByEmailInputModel model)
	{
		try
		{
			_service.PostByEmail(model);

			return Ok("Money Transferred!");
		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
		catch(WithoutMoneyException)
		{
			return BadRequest();
		}
	}

	/// <summary>
	///     Transfer money by CPF
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <response code="400">Bad Request</response>
	/// <returns>Money Transferred!</returns>
	[HttpPost("pix/cpf")]
	public IActionResult PostByCpf(TransactionByCpfInputModel model)
	{
		try
		{
			_service.PostByCpf(model);

			return Ok("Money Transferred!");
		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
		catch(WithoutMoneyException)
		{
			return BadRequest();
		}
	}

	/// <summary>
	///     Transfer money by PhoneNumber
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <response code="400">Bad Request</response>
	/// <returns>Money Transferred!</returns>
	[HttpPost("pix/phone")]
	public IActionResult PostByPhoneNumber(TransactionByPhoneNumberInputModel model)
	{
		try
		{
			_service.PostByPhoneNumber(model);

			return Ok("Money Transferred!");
		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
		catch(WithoutMoneyException)
		{
			return BadRequest();
		}
	}

	/// <summary>
	///		Transfer money by TED
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <response code="400">Bad Request</response>
	/// <returns>Money Transferred!</returns>
	[HttpPost("ted")]
	public IActionResult PostByTed(TransactionByTedAndDocInputModel model)
	{
		try
		{
			_service.PostByTed(model);

			return Ok("Money Transferred!");
		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
		catch (WithoutMoneyException)
		{
			return BadRequest();
		}
		catch (ManyDifferentException)
		{
			return BadRequest();
		}
		catch (WeekendException)
		{
			return BadRequest("Transaction not allowed on weekends!");
		}
		catch (OvertimeException)
		{
			return BadRequest(("Transactions are allowed from 8AM to 22PM!"));
		}
	}

	/// <summary>
	///		Transfer money by DOC
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <response code="400">Bad Request</response>
	/// <returns>Money Transferred!</returns>
	[HttpPost("doc")]
	public IActionResult PostByDoc(TransactionByTedAndDocInputModel model)
	{
		try
		{
			_service.PostByTed(model);

			return Ok("Money Transferred!");
		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
		catch (WithoutMoneyException)
		{
			return BadRequest();
		}
		catch (ManyDifferentException)
		{
			return BadRequest();
		}
		catch (WeekendException)
		{
			return BadRequest("Transaction not allowed on weekends!");
		}
		catch (OvertimeException)
		{
			return BadRequest("Transactions are allowed from 8AM to 5PM!");
		}
		catch (LimitExceededException)
		{
			return BadRequest("Transaction limit less than or equal to 4,999!");
		}
	}
}
