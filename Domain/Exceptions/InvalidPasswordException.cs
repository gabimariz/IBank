namespace Domain.Exceptions;

public class InvalidPasswordException : Exception
{
	public InvalidPasswordException()
		: base("This password is incorrect!") {}
}
