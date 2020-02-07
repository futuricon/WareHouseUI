using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IProductRepository:IGenericRepository<Product>
	{
		IEnumerable<Product> GetOrderWithRelations { get; }

	}

	public class ProductRepository: GenericRepository<Product>,IProductRepository
	{
		ApplicationDbContext _dbContext;
		public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Product> GetOrderWithRelations => _dbContext.Products
			  .Include(x => x.WareHouse)
			  .Include(x => x.Category)
			  .AsNoTracking();
	}
}
