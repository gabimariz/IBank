namespace Domain.Exceptions;

public class ExistingAccountException : Exception
{
	public ExistingAccountException()
		: base ("An account with this email already exists!") {}
}
