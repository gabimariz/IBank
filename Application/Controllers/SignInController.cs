using Application.InputModels;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class SignInController : ControllerBase
{
	private readonly ISignInService _signInService;
	private readonly ITokenService _tokenService;

	public SignInController(ISignInService signInService, ITokenService tokenService)
	{
		_signInService = signInService;
		_tokenService = tokenService;
	}

	[HttpPost]
	public ActionResult<dynamic> AuthenticateAsync([FromBody] SignInInputModel signIn)
	{
		var user = _signInService.SignIn(signIn.Email!, signIn.Password!);

		if (user == null!)
			return NotFound(new { message = "user not found!" });

		var token = _tokenService.GenerateToken(user);

		return new
		{
			user,
			token
		};
	}
}
