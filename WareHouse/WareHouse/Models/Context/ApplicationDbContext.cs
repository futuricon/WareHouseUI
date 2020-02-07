using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Identity;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Context
{
	public class ApplicationDbContext :DbContext
	{
		public string connString = string.Empty;
		public ApplicationDbContext(IConnectionHelper connectionHelper)
		{
			connString = connectionHelper.ConnectionString;
			NpgsqlConnection.GlobalTypeMapper.MapEnum<Role>();
			Database.EnsureCreated();
		}

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{		
			optionsBuilder.UseNpgsql(connString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasPostgresEnum<Role>();

			//modelBuilder.Entity<IncomeItemIncome>()
			//	.HasKey(x => new { x.IncomeId, x.IncomeItemId });
			//modelBuilder.Entity<OrderItemOrder>()
			//	.HasKey(x => new { x.OrderId, x.OrderItemId });

			//modelBuilder.Entity<IncomeItemIncome>()
			//	.HasOne(c => c.Income)
			//	.WithMany(c => c.IncomeItemCollection)
			//	.HasForeignKey(x => x.IncomeId);

			//modelBuilder.Entity<IncomeItemIncome>()
			//	.HasOne(c => c.IncomeItem)
			//	.WithMany(c => c.IncomeItemCollection)
			//	.HasForeignKey(x => x.IncomeItemId);

			//modelBuilder.Entity<OrderItemOrder>()
			//	.HasOne(c => c.Order)
			//	.WithMany(c => c.OrderItemCollection)
			//	.HasForeignKey(x => x.OrderId);

			//modelBuilder.Entity<OrderItemOrder>()
			//	.HasOne(c => c.OrderItem)
			//	.WithMany(c => c.OrderItemCollection)
			//	.HasForeignKey(x => x.OrderItemId);
		}


	
		public DbSet<Category> Categories { get; set; }

		public DbSet<Client> Clients { get; set; }
		public DbSet<Expense> Expenses { get; set; }
		public DbSet<Income> Incomes { get; set; }
		public DbSet<IncomeItem> IncomeItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<WareHouseTable> WareHouseTables { get; set; }
		public DbSet<ProviderTable> Providers { get; set; }
	}
}
