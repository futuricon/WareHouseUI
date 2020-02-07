using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public class SeedData
	{
		ApplicationDbContext context;
		public SeedData(ApplicationDbContext app)
		{
			context = app;
		}

		public void SetInitial()
		{
			WareHouseTable houseTable1 = new WareHouseTable()
			{
				Title = "Завод 1",
				Status = true,
				Type = 1,
			};
			WareHouseTable houseTable2 = new WareHouseTable()
			{
				Title = "Фабрика 1",
				Status = true,
				Type = 2,
			};

			Category category1 = new Category
			{
				Title = "Овощи"
			};
			Category category2 = new Category
			{
				Title = "Фрукты"
			};
			Product product1 = new Product
			{
				Title = "Помидор",
				Count = 1,
				CostPrice = 2500,
				BarCode = "111"
			};
			Product product2 = new Product
			{
				Title = "Огурец",
				Count = 1,
				CostPrice = 3500,
				BarCode = "222"
			};
			Product product3 = new Product
			{
				Title = "Яблоко",
				Count = 1,
				CostPrice = 5000,
				BarCode = "333"
			};
			Product product4 = new Product
			{
				Title = "Груша",
				Count = 1,
				CostPrice = 10000,
				BarCode = "4444"
			};
			category1.Products = new List<Product> { product1, product2 };
			category2.Products = new List<Product> { product3, product4 };

			houseTable1.Products = new List<Product> { product1, product2, product4 };
			houseTable2.Products = new List<Product> { product1, product2, product4,product3 };

			context.Add(houseTable1);
			context.Add(houseTable2);
			context.Add(category1);
			context.Add(category2);
			context.SaveChanges();

		}

		public void SetIncome()
		{
			var products = context.Products.ToList();
			var p1 = products.FirstOrDefault();
			var p2 = products.LastOrDefault();
			var houses = context.WareHouseTables.ToList();
			var h1 = houses.FirstOrDefault();

			Income income1 = new Income
			{
				Date = DateTime.Now,
				ChangedDate = DateTime.Now,
			};
			IncomeItem incomeItem1 = new IncomeItem
			{
				Count = 4,
				Price = 5000,
				Product = p1
			};
			IncomeItem incomeItem2 = new IncomeItem
			{
				Count = 10,
				Price = 3000,
				Product = p1
			};

			IncomeItem incomeItem3 = new IncomeItem
			{
				Count = 2,
				Price = 1000,
				Product = p2
			};

			IncomeItem incomeItem4 = new IncomeItem
			{
				Count = 8,
				Price = 4500,
				Product = p2
			};

			income1.IncomeItemCollection = new List<IncomeItem> { incomeItem1, incomeItem2, incomeItem3, incomeItem4 };
			context.Add(income1);
			context.SaveChanges();
		}

		public void SetExpense()
		{
			var ex = new Expense
			{
				Amount = 20000,
				Comment = "Тут коментарии"
			};
			var ex2 = new Expense
			{
				Amount = 30000,
				Comment = "Тут коментарии"
			};
			var ex3 = new Expense
			{
				Amount = 40000,
				Comment = "Тут коментарии"
			};
			var ex4 = new Expense
			{
				Amount = 50000,
				Comment = "Тут коментарии"
			};
			var ex5 = new Expense
			{
				Amount = 60000,
				Comment = "Тут коментарии"
			};
			context.AddRange(new List<Expense>() { ex, ex2, ex3, ex4, ex5 });
			context.SaveChanges();
		}

	}
}
