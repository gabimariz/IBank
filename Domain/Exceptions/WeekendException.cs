namespace Domain.Exceptions;

public class WeekendException : Exception
{
	public WeekendException()
		: base("It is not possible to transfer us weekends!") {}
}
