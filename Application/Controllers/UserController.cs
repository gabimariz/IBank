using Application.InputModels;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService<UserInputModel> _userService;

	public UserController(IUserService<UserInputModel> userService)
	{
		_userService = userService;
	}

	/// <summary>
	///		Find user by Id
	/// </summary>
	/// <param name="id">User id</param>
	/// <response code="200">Return user found by id</response>
	/// <response code="404">User not found</response>
	[HttpGet("{id}")]
	[Authorize(Roles = "User")]
	public ActionResult<User> GetById([FromRoute] Guid id)
	{
		try
		{
			return _userService.GetById(id);

		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
	}

	/// <summary>
	///		Add new user
	/// </summary>
	/// <param name="user">User data</param>
	/// <response code="201">Created user</response>
	/// <response code="422">There is already a registered user</response>
	[HttpPost]
	public IActionResult Post([FromBody] UserInputModel user)
	{
		try
		{
			var findCpf = _userService.GetByCpf(user.Cpf!);
			var findEmail = _userService.GetByEmail(user.Email!);

			if(findCpf == null! || findEmail == null!)
				_userService.Insert(user);

			return Ok("Account create successfully!");
		}
		catch (RegisteredUserException)
		{
			return UnprocessableEntity("There is already a user already registered!");
		}
	}

	/// <summary>
	///		Delete user by id
	/// </summary>
	/// <param name="id">User data</param>
	/// <response code="200">delete user</response>
	/// <response code="422">If there is no user</response>
	[HttpDelete("{id}")]
	[Authorize]
	public IActionResult Delete([FromRoute] Guid id)
	{
		var deleteUser = _userService.Delete(id);

		if (!deleteUser.Contains("deleted"))
			return UnprocessableEntity(deleteUser);

		return Ok("Account deleted successfully!");
	}
}
