namespace Domain.Exceptions;

public class WeekendExpection : Exception
{
	public WeekendExpection()
		: base("transfers are not allowed on weekends") {}
}
