using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class SignInService : ISignInService
{
	private readonly IUserRepository _repository;

	/// <summary>
	///     Repository dependency injection
	/// </summary>
	/// <param name="repository"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public SignInService(IUserRepository repository)
	{
		_repository = repository;
	}

	/// <summary>
	///     Sign In by user EMAIL
	/// </summary>
	/// <param name="model"></param>
	/// <returns>User</returns>
	/// <exception cref="EmailNotFoundException"></exception>
	/// <exception cref="InvalidPasswordException"></exception>
	public User GetByEmail(SignInInputModel model)
	{
		var user = _repository.GetByEmail(model.Email!);

		if(user == null)
			throw new EmailNotFoundException();

		if(BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
			return user;

		throw new InvalidPasswordException();

    }
}
