using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.ViewModels
{
	public class OrderViewModel
	{
		public IEnumerable<OrderItem> OrderItems { get; set; }
		public DateTime Date { get; set; }
		public double Total { get; set; }
		public IEnumerable<Client> Client { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<WareHouseTable> WareHouses { get; set; }
		public int SelectedClientId { get; set; }
	}
}
