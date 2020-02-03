using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class OrderItem
	{
		public OrderItem()
		{
			Products = new List<Product>();
		}
		public int Id { get; set; }
		public double Price { get; set; }
		public double Count { get; set; }

		public ICollection<Product> Products { get; set; }
		public ICollection<OrderItemOrder> OrderItemCollection { get; set; }

	}
}
