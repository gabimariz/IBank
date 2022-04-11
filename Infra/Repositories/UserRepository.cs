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
		var user = _appDbContext.Users!.Find(id);

		_appDbContext.Users.Remove(user!);
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
