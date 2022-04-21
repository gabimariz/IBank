namespace Domain.Interfaces;

public interface IPixRepository
{
	void TransferByCpf(double money, Guid to, Guid from);
	void Save();
}
