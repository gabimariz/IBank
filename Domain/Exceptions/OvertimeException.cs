namespace Domain.Exceptions;

public class OvertimeException : Exception
{
	public OvertimeException()
		: base("transfer time exceeded") {}
}
