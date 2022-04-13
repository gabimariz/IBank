using Application.InputModels;
using Domain.Entities;
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

	public string GetByCpf(string cpf)
	{
		return _userRepository.GetByCpf(cpf);
	}

	public string Insert(UserInputModel user)
	{

			_userRepository.Insert(new User
			{
				Id = Guid.NewGuid(),
				FullName = user.FullName,
				Cpf = user.Cpf,
				Account = new Account
				{
					Id = Guid.NewGuid(),
					Bill =  GenerateAccount.New(),
					Agency = "0001",
					Money = 0,
				},
				Email = user.Email,
				Password = user.Password,
			});

			_userRepository.Save();

			return "create";

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
