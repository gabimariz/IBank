namespace Domain.Exceptions;

public class WithoutMoneyException : Exception
{
	public WithoutMoneyException()
		: base("Not enough money") {}
}
