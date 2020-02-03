using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Context
{
	public class ApplicationDbContext :DbContext
	{
		public string connString = string.Empty;
		public ApplicationDbContext(IConnectionHelper connectionHelper)
		{
			connString = connectionHelper.ConnectionString;
		}
		public ApplicationDbContext() 
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IncomeItemIncome>()
				.HasKey(x => new { x.IncomeId, x.IncomeItemId });
			modelBuilder.Entity<OrderItemOrder>()
				.HasKey(x => new { x.OrderId, x.OrderItemId });

			modelBuilder.Entity<IncomeItemIncome>()
				.HasOne(c => c.Income)
				.WithMany(c => c.IncomeItemCollection)
				.HasForeignKey(x => x.IncomeId);

			modelBuilder.Entity<IncomeItemIncome>()
				.HasOne(c => c.IncomeItem)
				.WithMany(c => c.IncomeItemCollection)
				.HasForeignKey(x => x.IncomeItemId);

			modelBuilder.Entity<OrderItemOrder>()
				.HasOne(c => c.Order)
				.WithMany(c => c.OrderItemCollection)
				.HasForeignKey(x => x.OrderId);

			modelBuilder.Entity<OrderItemOrder>()
				.HasOne(c => c.OrderItem)
				.WithMany(c => c.OrderItemCollection)
				.HasForeignKey(x => x.OrderItemId);
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (connString == string.Empty) connString = "Server=127.0.0.1;Port=5432;Database=warehouse;User Id=postgres;Password=postgres;";
			
			optionsBuilder.UseNpgsql(connString);
		}
		public DbSet<Category> Categories { get; set; }

		public DbSet<Client> Clients { get; set; }
		public DbSet<Exemption> Exemptions { get; set; }
		public DbSet<Income> Incomes { get; set; }
		public DbSet<IncomeItem> IncomeItems { get; set; }
		public DbSet<IncomeItemIncome> IncomeItemIncomes { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<OrderItemOrder> OrderItemOrders { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<WareHouseTable> WareHouseTables { get; set; }

	}
}
