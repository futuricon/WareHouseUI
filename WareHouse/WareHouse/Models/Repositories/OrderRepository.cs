using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IOrderRepository:IGenericRepository<Order>
	{
	      IEnumerable<Order> GetOrderWithRelations { get; }
	}

	public class OrderRepository:GenericRepository<Order> ,IOrderRepository
	{
		ApplicationDbContext _dbContext;
		public OrderRepository(ApplicationDbContext context):base(context)
		{
			_dbContext = context;
		}

		public IEnumerable<Order> GetOrderWithRelations => _dbContext.Orders.Include(x => x.Client).
			Include(x=>x.OrderItemCollection).AsNoTracking();
	}
}
