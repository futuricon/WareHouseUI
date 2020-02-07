using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WareHouse.Models.Infrastructure;

namespace WareHouse.Models.DbModels
{
	public class OrderItem : NotifyChangedPropertyBase, IEntity
	{
		private Product product;
		private WareHouseTable wareHouse;
		private double price;

		public int Id { get; set; }
		public double Price { get => price; set { price = value; OnPropertyChanged(); } }
		public double Count { get; set; }

		public Product Product
		{
			get => product;
			set
			{
				product = value;
				if (Product != null)
				{
					Price = Product.CostPrice;
					ProductId = Product.Id;
					product = null;
				}
			}
		}
		public int ProductId { get; set; }

		public int OrderId { get; set; }
		public Order Order { get; set; }

		[NotMapped]
		public WareHouseTable WareHouse { get => wareHouse; set { wareHouse = value; OnPropertyChanged(); } }

	}
}
