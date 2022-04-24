namespace Domain.Exceptions;

public class LimitExceededException : Exception
{
	public LimitExceededException()
		: base("value over limit") {}
}
