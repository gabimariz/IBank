using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class AppDbContext : DbContext
{
	public DbSet<User>? Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySql("server=localhost;username=root;password=root;database=ibank",
			new MariaDbServerVersion(new Version(10, 6, 7)));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Configure Student & StudentAddress entity
		modelBuilder.Entity<User>()
			.HasOne(s => s.Account);
	}
}
