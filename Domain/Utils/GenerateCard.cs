namespace Domain.Utils;

public static class GenerateCard
{
	public static string New()
	{
		Random random = new Random(DateTime.Now.Millisecond);

		int[] card = new int[15];
		var soma = 0;

		for(int i = 0; i <= 14; i++)
		{
			card[i] = random.Next(0, 9);
		}

		int[] numberInverse = card.Reverse().ToArray();

		for(int i = 0; i <= 14; i++)
		{
			if(numberInverse[i] % 2 != 0)
				numberInverse[i] *= 2;

			if(numberInverse[i] > 9)
				numberInverse[i] -= 9;
			soma += numberInverse[i];
		}

		return string.Join("", card.ToArray()) + (soma % 10);
	}

	public static string Cvv()
	{
		Random random = new Random(DateTime.Now.Millisecond);

		int[] cvv = new int[3];

		for(int i = 0; i <= 2; i++)
		{
			cvv[i] = random.Next(0, 9);
		}

		return string.Join("", cvv.ToArray());
	}
}
