using Application.InputModels;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class PixController : ControllerBase
{
	private readonly IPixService _pixService;

	public PixController(IPixService pixService)
	{
		_pixService = pixService;
	}

	[HttpPost("Cpf")]
	[Authorize]
	public ActionResult<PixTransfer> TransferByCpf([FromBody] PixTransferByCpfInputModel transfer)
	{
		try
		{
			return _pixService.TransferByCpf(transfer.Money, transfer.ToCpf!, transfer.FromId);
		}
		catch (WithoutMoneyException)
		{
			return UnprocessableEntity("Insufficient value!");
		}
	}

	[HttpPost("Email")]
	[Authorize]
	public ActionResult<PixTransfer> TransferByEmail([FromBody] PixTransferByEmailInputModel transfer)
	{
		try
		{
			return _pixService.TransferByEmail(transfer.Money, transfer.ToEmail!, transfer.FromId);
		}
		catch (WithoutMoneyException)
		{
			return UnprocessableEntity("Insufficient value!");
		}
	}

	[HttpPost("Phone")]
	[Authorize]
	public ActionResult<PixTransfer> TransferByPhone([FromBody] PixTransferByPhoneInputModel transfer)
	{
		try
		{
			return _pixService.TransferByPhone(transfer.Money, transfer.ToPhone!, transfer.FromId);
		}
		catch (WithoutMoneyException)
		{
			return UnprocessableEntity("Insufficient value!");
		}
	}
}
