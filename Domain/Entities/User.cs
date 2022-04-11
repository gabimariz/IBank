namespace Domain.Entities;

public class User
{
	public Guid Id { get; set; }

	public string? FullName { get; set; }

	public string? Cpf { get; set; }

	public virtual Account? Account { get; set; }

	public string? Agency { get; set; }

	public string? Email { get; set; }

	public string? Password { get; set; }
}
