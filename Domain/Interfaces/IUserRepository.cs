using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository : IDisposable
{
  List<User> Get();

  User GetById(Guid id);

  Profile GetByProfileId(Guid id);

  User GetByEmail(string email);

  User GetByCpf(string cpf);

  User GetByPhoneNumber(string phoneNumber);

  void Post(User user);

  void Delete(Guid id);

  void Save();
}
