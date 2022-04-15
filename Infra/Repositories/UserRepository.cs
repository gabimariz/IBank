using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _appDbContext;

	public UserRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public User SignIn(string email, string password)
	{
		var user = _appDbContext.Users!.FirstOrDefault(p => p.Email == email)!;

		return BCrypt.Net.BCrypt.Verify(password, user.Password) ? user : null!;
	}

	public User GetById(Guid id)
	{
		return _appDbContext.Users!
			.Include(p => p.Account)
			.FirstOrDefault(p => p.Id == id)!;

	}

	public string GetByCpf(string cpf)
	{
		var user = _appDbContext.Users!.Single(p => p.Cpf == cpf);

		return user.Cpf!;
	}

	public void Insert(User user)
	{
		_appDbContext.Users!.Add(user);
	}

	public void Update(User user)
	{
		_appDbContext.Entry(user).State = EntityState.Modified;
	}

	public void Delete(Guid id)
	{
		var user = _appDbContext.Users!
			.Where(p => p.Id == id)
			.Include(p => p.Account)
			.FirstOrDefault();

		_appDbContext.Users!.Remove(user!);
	}

	public void Save()
	{
		_appDbContext.SaveChanges();
	}

	public void Dispose()
	{
		 _appDbContext.Dispose();
	}
}
