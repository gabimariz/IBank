using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class AppDbContext : DbContext
{
	public DbSet<User>? Users { get; set; }
	public DbSet<PixTransfer>? PixTransfers { get; set; }

	public DbSet<BankTransaction>? BankTransactions { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySql("server=localhost;username=root;password=root;database=ibank",
			new MariaDbServerVersion(new Version(10, 6, 7)));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Configure Student & StudentAddress entity
		modelBuilder.Entity<Account>()
			.HasOne<User>(e => e.User)
			.WithOne(d => d.Account)
			.HasForeignKey<Account>(e => e.UserId)
			.IsRequired(true)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<User>()
			.HasIndex(i => i.Email).IsUnique();

		modelBuilder.Entity<User>()
			.HasIndex(i => i.Cpf).IsUnique();

		modelBuilder.Entity<Card>()
			.HasOne<User>(e => e.User)
			.WithOne(d => d.Card)
			.HasForeignKey<Card>(e => e.UserId)
			.IsRequired(true)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Card>()
			.HasIndex(i => i.Number).IsUnique();
	}
}
