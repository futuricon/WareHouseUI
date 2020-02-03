using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
		void SetInitial();
	}

	public class ProductRepositroy: IProductRepository
	{
		ApplicationDbContext dbContext;
		public ProductRepositroy(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IEnumerable<Product> Products => dbContext.Products.AsNoTracking();

		public void SetInitial()
		{
			dbContext.Add<Product>(new Product
			{
				BarCode = "test",
				ChangedDate = DateTime.Now,
				CostPrice = 100,
				LastSync = DateTime.Now,
				Title = "Помидор",
				Price = 500,
				Category =new Category
				{
					ChangedDate = DateTime.Now,
					LastSync = DateTime.Now,
					Title="Овощи"
				},
				WareHouse =new WareHouseTable
				{
					Title="ЗАВОД1"
				}
			});
			dbContext.SaveChanges();
		}
	}
}
