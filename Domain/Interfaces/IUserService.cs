using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserService<in T>
{
	User GetById(Guid id);
	User GetByCpf(string cpf);

	string Insert(T user);

	string Update(User user);

	string Delete(Guid id);
}
