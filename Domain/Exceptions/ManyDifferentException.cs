namespace Domain.Exceptions;

public class ManyDifferentException : Exception
{
	public ManyDifferentException()
		: base("The values are different!") {}
}
