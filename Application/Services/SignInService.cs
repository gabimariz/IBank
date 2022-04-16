using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class SignInService : ISignInService
{
	private readonly IUserRepository _userRepository;

	public SignInService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public User SignIn(string email, string password)
	{
		try
		{
			return _userRepository.SignIn(email, password);
		}
		catch (Exception)
		{
			return null!;
		}
	}
}
