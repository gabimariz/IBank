using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v2")]
public class SignInController : ControllerBase
{
	private readonly ISignInService _signIn;
	private readonly ITokenService _token;

	/// <summary>
	///     SignIn and Token Service dependency injection
	/// </summary>
	/// <param name="signIn"></param>
	/// <param name="token"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public SignInController(ISignInService signIn, ITokenService token)
	{
		_signIn = signIn;
		_token = token;
	}

	/// <summary>
	///     Sign in user account
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <response code="400">Bad Request</response>
	/// <returns>User, Token</returns>
	[HttpPost("signin")]
	public ActionResult<dynamic> Post(SignInInputModel model)
	{
		try
		{
			var user = _signIn.GetByEmail(model);

			var token = _token.Get(user);

			return Ok(
				new
				{
					user,
					token
				});
		}
		catch (EmailNotFoundException err)
		{
			return NotFound(new { message = err });
		}
		catch (InvalidPasswordException err)
		{
			return BadRequest(new { message = err });
		}
	}
}
