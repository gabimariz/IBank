using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserService<T>
{
	string GetByCpf(string cpf);

	string Insert(T user);

	string Update(User user);

	string Delete(Guid id);
}
