using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces;

public interface ISignInService
{
	User GetByEmail(SignInInputModel email);
}
