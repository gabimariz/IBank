using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class AppDbContext : DbContext
{
	public DbSet<User>? Users { get; set; }

	public DbSet<Profile>? Profiles { get; set; }

	public DbSet<BankAccount>? BankAccounts { get; set; }

	public DbSet<Card>? Cards { get; set; }

	public DbSet<BankTransaction>? BankTransactions { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseMySql("server=localhost;username=root;password=root;database=ibank",
			new MariaDbServerVersion(new Version(10, 6, 7)));
	}

	protected override void OnModelCreating(ModelBuilder model)
	{
		model.Entity<User>()
			.Property(p => p.Email)
			.IsRequired()
			.HasMaxLength(50);

		model.Entity<User>()
			.Property(p => p.Password)
			.IsRequired();

		model.Entity<Profile>()
			.HasOne(p => p.User)
			.WithOne(p => p.Profile)
			.HasForeignKey<Profile>(p => p.FkUser)
			.OnDelete(DeleteBehavior.Cascade)
			.IsRequired();

		model.Entity<Profile>()
			.Property(p => p.Cpf)
			.HasMaxLength(14)
			.IsRequired();

		model.Entity<Profile>()
			.HasIndex(p => p.Cpf)
			.IsUnique();

		model.Entity<Profile>()
			.Property(p => p.PhoneNumber)
			.HasMaxLength(15)
			.IsRequired();

		model.Entity<Profile>()
			.HasIndex(p => p.PhoneNumber)
			.IsUnique();

		model.Entity<BankAccount>()
			.HasOne(p => p.Profile)
			.WithOne(p => p.BankAccount)
			.HasForeignKey<BankAccount>(p => p.FkProfile)
			.OnDelete(DeleteBehavior.Cascade)
			.IsRequired();

		model.Entity<BankAccount>()
			.Property(p => p.Bill)
			.IsRequired();

		model.Entity<BankAccount>()
			.HasIndex(p => p.Bill)
			.IsUnique();

		model.Entity<BankAccount>()
			.Property(p => p.Agency)
			.IsRequired();

		model.Entity<BankAccount>()
			.Property(p => p.Money)
			.IsRequired();

		model.Entity<BankAccount>()
			.Property(p => p.Type)
			.IsRequired();

		model.Entity<Card>()
			.HasOne(p => p.Profile)
			.WithOne(p => p.Card)
			.HasForeignKey<Card>(p => p.FkProfile)
			.OnDelete(DeleteBehavior.Cascade)
			.IsRequired();

		model.Entity<Card>()
			.Property(p => p.Password)
			.IsRequired();

		model.Entity<BankTransaction>()
			.Property(p => p.Money)
			.IsRequired();
	}
}
