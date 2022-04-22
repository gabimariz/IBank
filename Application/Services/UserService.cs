using Application.InputModels;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Application.Services;

public class UserService : IUserService<UserInputModel>
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public User GetById(Guid id)
	{
		var user = _userRepository.GetById(id);

		if (user == null) throw new UserNotFoundException();

		return user;
	}
	public User GetByCpf(string cpf)
	{
		var user = _userRepository.GetByCpf(cpf);

		if (user != null) throw new RegisteredUserException();

		return null!;
	}

	public User GetByEmail(string email)
	{
		var user = _userRepository.GetByEmail(email);

		if (user != null) throw new RegisteredUserException();

		return null!;
	}

	public User GetByPhone(string phoneNumber)
	{
		var user = _userRepository.GetByPhone(phoneNumber);

		if (user != null) throw new RegisteredUserException();

		return null!;
	}

	public void Insert(UserInputModel user)
	{

			_userRepository.Insert(new User
			{
				Id = Guid.NewGuid(),
				FullName = user.FullName,
				Cpf = user.Cpf,
				PhoneNumber = user.PhoneNumber,
				Account = new Account
				{
					Id = Guid.NewGuid(),
					Bill =  GenerateAccount.New(),
					Agency = "0001",
					Money = 0,
				},
				Email = user.Email,
				Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
				Role = Roles.User
			});

			_userRepository.Save();

	}

	public string Update(User user)
	{
		try
		{
			_userRepository.Update(new User
			{
				Id = user.Id,
				FullName = user.FullName,
				Cpf = user.Cpf,
				Account = user.Account,
				Email = user.Email,
				Password = user.Password,
			});

			_userRepository.Save();

			return "Account successfully updated!";
		}
		catch (Exception err)
		{
			return($"{nameof(user)} could not be update: {err.Message}");
		}
	}

	public string Delete(Guid id)
	{
		try
		{
			_userRepository.Delete(id);
			_userRepository.Save();

			return "deleted";
		}
		catch (Exception err)
		{
			return($"{nameof(id)}: {err.Message}");
		}
	}
}
