using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class Category
	{
		public Category()
		{
			Products = new List<Product>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		[JsonProperty(PropertyName = "changed_date")]
		public DateTime ChangedDate { get; set; }
		[JsonProperty(PropertyName = "last_sync")]
		public DateTime LastSync { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
