using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class OrderItemOrder
	{
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public int OrderItemId { get; set; }
		public OrderItem OrderItem { get; set; }
	}
}
