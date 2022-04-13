using System.ComponentModel;
using Application.InputModels;
using Domain.Interfaces;
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
	///		Add new user
	/// </summary>
	/// <param name="user">User data</param>
	/// <response code="201">Created user</response>
	/// <response code="422">There is already a registered user</response>
	[HttpPost]
	public IActionResult Post([FromBody] UserInputModel user)
	{
		var createUser = _userService.Insert(user);

		if(!createUser.Contains("create"))
			return UnprocessableEntity(createUser);

		return Created(createUser, "Account create successfully!");
	}

	// <summary>
	///		Delete user by id
	/// </summary>
	/// <param name="id">User data</param>
	/// <response code="200">delete user</response>
	/// <response code="422">If there is no user</response>
	[HttpDelete("{id}")]
	public IActionResult Delete(Guid id)
	{
		var deleteUser = _userService.Delete(id);

		if (!deleteUser.Contains("deleted"))
			return UnprocessableEntity(deleteUser);

		return Ok("Account deleted successfully!");
	}
}
