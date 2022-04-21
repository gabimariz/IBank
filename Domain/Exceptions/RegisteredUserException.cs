namespace Domain.Exceptions;

public class RegisteredUserException : Exception
{
	public RegisteredUserException()
		: base("User already registered") {}
}
