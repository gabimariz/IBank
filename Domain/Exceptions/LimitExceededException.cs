namespace Domain.Exceptions;

public class LimitExceededException : Exception
{
	public LimitExceededException()
		: base("Limit exceeded!") {}
}
