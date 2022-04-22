namespace Domain.Interfaces;

public interface IPixRepository
{
	void Transfer(double money, Guid to, Guid from);

	void Save();
}
