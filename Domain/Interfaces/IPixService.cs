using Domain.Entities;

namespace Domain.Interfaces;

public interface IPixService
{
	PixTransfer TransferByCpf(double money, string toCpf, Guid fromId);

	PixTransfer TransferByEmail(double money, string toEmail, Guid fromId);

	PixTransfer TransferByPhone(double money, string toPhone, Guid fromId);

	PixTransfer TransferById(Guid id);
}
