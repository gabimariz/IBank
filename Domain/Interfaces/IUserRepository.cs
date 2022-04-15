using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository : IDisposable
{
	User SignIn(string email, string password);

	User GetById(Guid id);
	string GetByCpf(string cpf);

	void Insert(User user);

	void Update(User user);

	void Delete(Guid id);

	void Save();
}
