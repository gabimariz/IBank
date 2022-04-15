using Domain.Entities;

namespace Domain.Interfaces;

public interface ISignInService
{
	User SignIn(string email, string password);
}
