using Domain.Entities;

namespace Domain.Interfaces;

public interface IPixRepository
{
	void Transfer(double money, Guid to, Guid from);

	PixTransfer TransferById(Guid id);

	void Save();
}
