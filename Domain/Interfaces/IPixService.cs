using Domain.Entities;

namespace Domain.Interfaces;

public interface IPixService
{
	PixTransfer Transfer(double money, string toCpf, Guid fromId);
}
