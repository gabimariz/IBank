using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces;

public interface IUserService
{
	List<User> Get();

	User GetById(Guid id);

	User GetByEmail(string email);

	User GetByCpf(string cpf);

	User GetByPhoneNumber(string phoneNumber);

	void Post(UserInputModel user);

	void Delete(Guid id);
}
