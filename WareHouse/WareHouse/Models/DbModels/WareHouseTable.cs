using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WareHouse.Models.DbModels
{
	[Table("WareHouse")]
	public class WareHouseTable
	{
		public WareHouseTable()
		{
			Products = new List<Product>();
			Incomes = new List<Income>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public int Type { get; set; }

		[JsonProperty(PropertyName = "changed_date")]
		public DateTime ChangedDate { get; set; }

		[JsonProperty(PropertyName = "last_sync")]
		public DateTime LastSync { get; set; }

		public ICollection<Product> Products { get; set; }
		public ICollection<Income> Incomes { get; set; }
	}
}
