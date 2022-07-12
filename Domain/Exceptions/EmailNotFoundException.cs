namespace Domain.Exceptions;

public class EmailNotFoundException : Exception
{
	public EmailNotFoundException()
		: base("Email not found!") {}
}
