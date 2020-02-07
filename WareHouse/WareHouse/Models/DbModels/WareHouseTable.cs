using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WareHouse.Models.Infrastructure;

namespace WareHouse.Models.DbModels
{
	[Table("WareHouses")]
	public class WareHouseTable : NotifyChangedPropertyBase, IEntity
	{
		private double _remainder;
		private string title;

		public WareHouseTable()
		{
			Products = new List<Product>();
			IncomeItems = new List<IncomeItem>();
			CalculateBalance();
		}
		public int Id { get; set; }
		public string Title { get => title; set { title = value;OnPropertyChanged(); } }
		public int Type { get; set; }

		[JsonProperty(PropertyName = "changed_date")]
		public DateTime ChangedDate { get; set; }

		[JsonProperty(PropertyName = "last_sync")]
		public DateTime? LastSync { get; set; }

		public bool Status { get; set; }

		public ICollection<Product> Products { get; set; }
		public ICollection<IncomeItem> IncomeItems { get; set; }

		[NotMapped]
		public double Remainder { get => _remainder; set { _remainder = value; OnPropertyChanged(); } }

		public double CalculateBalance()
		{
			Remainder = 0;
			if (Products == null || Products.Count == 0) return Remainder;

			foreach (var p in Products)
			{
				Remainder += p.Count * p.CostPrice;
			}
			return Remainder;
		}
	}
}
