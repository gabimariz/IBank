namespace Domain.Exceptions;

public class UnlinkedCardException : Exception
{
	public UnlinkedCardException()
		: base("no card found") {}
}
