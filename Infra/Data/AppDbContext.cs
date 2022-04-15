using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class AppDbContext : DbContext
{
	public DbSet<User>? Users { get; set; }
	public DbSet<PixTransfer>? PixTransfers { get; set; }

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
	}
}
