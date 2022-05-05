namespace Domain.Exceptions;

public class NothingWasFoundException : Exception
{
	public NothingWasFoundException()
		: base("nothing was found") {}
}
