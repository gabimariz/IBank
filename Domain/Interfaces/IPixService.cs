using Domain.Entities;

namespace Domain.Interfaces;

public interface IPixService
{
	PixTransfer TransferByCpf(double money, string toCpf, Guid fromId);
}
