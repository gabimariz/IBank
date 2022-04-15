using Domain.Entities;

namespace Domain.Interfaces;

public interface ITokenService
{
	string GenerateToken(User user);
}
