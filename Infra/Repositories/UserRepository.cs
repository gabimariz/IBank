using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _context;

	/// <summary>
	///     Context dependency injection
	/// </summary>
	/// <param name="context"></param>
	/// <remarks>DON'T MOVE HERE</remarks>
	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	/// <summary>
	///     Get all users in database
	/// </summary>
	/// <returns>List of users</returns>
	public List<User> Get()
	{
		return _context.Users!
			.Include(p => p.Profile)
			.Include(p => p.Profile!.BankAccount)
			.Include(p => p.Profile!.Card)
			.ToList();
	}

	/// <summary>
	///     Get user by ID in database
	/// </summary>
	/// <param name="id"></param>
	/// <returns>User</returns>
	public User GetById(Guid id)
	{
		return _context.Users!
			.Include(p => p.Profile)
			.Include(p => p.Profile!.BankAccount)
			.Include(p => p.Profile!.Card)
			.FirstOrDefault(p => p.Id == id)!;
	}

	/// <summary>
	///		Get profile by ID
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Profile</returns>
	public Profile GetByProfileId(Guid id)
	{
		return _context.Profiles!
			.Include(p => p.BankAccount)
			.Include(p => p.Card)
			.FirstOrDefault(p => p.Id == id)!;
	}

	/// <summary>
	///     Get user by EMAIL in database
	/// </summary>
	/// <param name="email"></param>
	/// <returns>User</returns>
	public User GetByEmail(string email)
	{
		return _context.Users!
			.Include(p => p.Profile)
			.Include(p => p.Profile!.BankAccount)
			.Include(p => p.Profile!.Card)
			.FirstOrDefault(p => p.Email == email)!;
	}

	/// <summary>
	///     Get user by CPF in database
	/// </summary>
	/// <param name="cpf"></param>
	/// <returns>User</returns>
	public User GetByCpf(string cpf)
	{
		return _context.Users!
			.Include(p => p.Profile)
			.Include(p => p.Profile!.BankAccount)
			.FirstOrDefault(p => p.Profile!.Cpf == cpf)!;
	}

	/// <summary>
	///     Get user by PhoneNumber in database
	/// </summary>
	/// <param name="phoneNumber"></param>
	/// <returns>User</returns>
	public User GetByPhoneNumber(string phoneNumber)
	{
		return _context.Users!
			.Include(p => p.Profile)
			.Include(p => p.Profile!.BankAccount)
			.Include(p => p.Profile!.Card)
			.FirstOrDefault(p => p.Profile!.Cpf == phoneNumber)!;
	}

	/// <summary>
	///     Create a new user in database
	/// </summary>
	/// <param name="user"></param>
	public void Post(User user)
	{
		_context.Users!.Add(user);

		Save();
	}

	/// <summary>
	///     Delete one user by ID in database
	/// </summary>
	/// <param name="id"></param>
	public void Delete(Guid id)
	{
		var user = _context.Users!
			.Where(p => p.Id == id)
			.Include(p => p.Profile)
			.FirstOrDefault();

		_context.Users!.Remove(user!);

		Save();
	}

	public void Save()
	{
		_context.SaveChanges();
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
