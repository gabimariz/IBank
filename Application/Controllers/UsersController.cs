using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("v2/user")]
public class UsersController : ControllerBase
{
	private readonly IUserService _service;

	/// <summary>
	///  Service dependency injection
	/// </summary>
	/// <param name="service"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public UsersController(IUserService service)
	{
		_service = service;
	}

	/// <summary>
	///  List all users
	/// </summary>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <returns>Users</returns>
	[HttpGet("list")]
	public ActionResult<User> GetAll()
	{
		try
		{
			return Ok(_service.Get());
		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
	}

	/// <summary>
	///		Find user by ID
	/// </summary>
	/// <param name="id"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <returns>User</returns>
	[HttpGet("{id}")]
	public ActionResult<User> GetById(Guid id)
	{
		try
		{
			return _service.GetById(id);
		}
		catch (UserNotFoundException)
		{
			return NoContent();
		}
	}

	/// <summary>
	///     Create a new user account
	/// </summary>
	/// <param name="model"></param>
	/// <response code="200">OK</response>
	/// <response code="422">Unprocessable Entity</response>
	/// <returns>Account create successfully!</returns>
	[HttpPost("signup")]
	public IActionResult Post(UserInputModel model)
	{
		try
		{
			_service.Post(model);

			return Ok("Account create successfully!");
		}
		catch (ExistingAccountException)
		{
			return UnprocessableEntity("There is already a user already registered!");
		}
	}

	/// <summary>
	///     Delete one user by ID
	/// </summary>
	/// <param name="id"></param>
	/// <response code="200">OK</response>
	/// <response code="204">No Content</response>
	/// <returns>Account deleted!</returns>
	[HttpDelete("{id}")]
	public IActionResult Delete(Guid id)
	{
		try
		{
			_service.Delete(id);

			return Ok("Account deleted!");
		}
		catch (EmailNotFoundException)
		{
			return NoContent();
		}
	}
}
