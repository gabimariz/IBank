using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Utils;

namespace Application.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _repository;

	/// <summary>
	///     Service dependency injection
	/// </summary>
	/// <param name="repository"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public UserService(IUserRepository repository)
	{
		_repository = repository;
	}

	/// <summary>
	///     Get all users in database
	/// </summary>
	/// <returns>all users</returns>
	/// <exception cref="UserNotFoundException"></exception>
	public List<User> Get()
	{
		var users = _repository.Get();

		if(users == null)
			throw new UserNotFoundException();

		return users;
	}

	/// <summary>
	///     Get one user by ID
	/// </summary>
	/// <param name="id"></param>
	/// <returns>User</returns>
	/// <exception cref="UserNotFoundException"></exception>
	public User GetById(Guid id)
	{
		var user = _repository.GetById(id);

		if(user == null)
			throw new UserNotFoundException();

		return user;
	}

	/// <summary>
	///     Get user by EMAIL
	/// </summary>
	/// <param name="email"></param>
	/// <returns>User</returns>
	/// <exception cref="EmailNotFoundException"></exception>
	public User GetByEmail(string email)
	{
		var user = _repository.GetByEmail(email);

		if(user == null)
			throw new EmailNotFoundException();

		return user;
	}

	/// <summary>
	///     Get user by CPF
	/// </summary>
	/// <param name="cpf"></param>
	/// <returns>User</returns>
	/// <exception cref="UserNotFoundException"></exception>
	public User GetByCpf(string cpf)
	{
		var user = _repository.GetByCpf(cpf);

		if(user == null)
			throw new UserNotFoundException();

		return user;
	}

	/// <summary>
	///     Get user by PhoneNumber
	/// </summary>
	/// <param name="phoneNumber"></param>
	/// <returns>User</returns>
	/// <exception cref="UserNotFoundException"></exception>
	public User GetByPhoneNumber(string phoneNumber)
	{
		var user = _repository.GetByPhoneNumber(phoneNumber);

		if(user == null)
			throw new UserNotFoundException();

		return user;
	}

	/// <summary>
	///     Create new user
	/// </summary>
	/// <param name="model"></param>
	/// <exception cref="ExistingAccountException"></exception>
	public void Post(UserInputModel model)
	{
		var user = _repository.GetByEmail(model.Email!);

		if(user != null)
			throw new ExistingAccountException();

		var userId = Guid.NewGuid();
		var profileId = Guid.NewGuid();

		_repository.Post(new User
		{
			Id = userId,
			Email = model.Email,
			Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
			Profile = new Profile
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Cpf = model.Cpf,
				PhoneNumber = model.PhoneNumber,
				FkUser = userId,
				BankAccount = new BankAccount
				{
					Id = profileId,
					Bill = GenerateBankAccount.New(),
					Agency = "0001",
					Money = 0,
					FkProfile = profileId,
					Type = model.AccountType,
					CreateAt = model.CreateAt,
					UpdateAt = model.UpdateAt
				},
				CreateAt = model.CreateAt,
				UpdateAt = model.UpdateAt
			},
			Role = Roles.User,
			CreateAt = model.CreateAt,
			UpdateAt = model.UpdateAt
		});
	}

	/// <summary>
	///     Delete user by ID
	/// </summary>
	/// <param name="id"></param>
	public void Delete(Guid id)
	{
		_repository.Delete(id);
	}
}
