using Application.InputModels;
using Domain.Entities;
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

	[HttpPost]
	[Authorize]
	public ActionResult<PixTransfer> Transfer([FromBody] PixTransferInputModel transfer)
	{
		return _pixService.Transfer(transfer.Money, transfer.ToCpf!, transfer.FromId);
	}
}
