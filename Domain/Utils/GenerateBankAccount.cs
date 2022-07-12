namespace Domain.Utils;

public static class GenerateBankAccount
{
	public static string New()
	{
		Random random = new Random(DateTime.Now.Millisecond);

		var randomNumber  = random.Next().ToString();

		return $"{randomNumber}-{(10 - ((int.Parse(randomNumber) * 10) % 10))}";

	}
}
