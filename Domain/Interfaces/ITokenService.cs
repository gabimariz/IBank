using Domain.Entities;

namespace Domain.Interfaces;

public interface ITokenService
{
	string Get(User user);
}
