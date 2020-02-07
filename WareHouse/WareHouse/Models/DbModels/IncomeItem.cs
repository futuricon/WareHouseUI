using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WareHouse.Models.Infrastructure;
namespace WareHouse.Models.DbModels
{
	public class IncomeItem : NotifyChangedPropertyBase, IEntity
	{
		private WareHouseTable wareHouse;
		private double price;
		private Product product;

		public int Id { get; set; }
		public double Price { get => price; set { price = value; OnPropertyChanged(); } }
		public double Count { get; set; }

		public int ProductId { get; set; }
		public Product Product { get => product; 
			set 
			{ 
				product = value;
				if (Product != null)
				{
					Price = Product.CostPrice;
					ProductId =Product.Id;
					product = null;
				}
			} 
		}

		public int IncomeId { get; set; }
		public Income Income { get; set; }

		public WareHouseTable WareHouse { get => wareHouse; set 
			{ 
				wareHouse = value; OnPropertyChanged();
				if (value != null)
				{
					WareHouseId = WareHouse.Id;
					WareHouse = null;
				}

			}
		}
		public int WareHouseId { get; set; }

	}
}
