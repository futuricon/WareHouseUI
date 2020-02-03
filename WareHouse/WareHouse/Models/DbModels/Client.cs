using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class Client
	{
		public Client()
		{
			Orders = new List<Order>();
		}
		public int Id { get; set; }
		public double Balance { get; set; }
		[JsonProperty(PropertyName ="changed_date")]
		public DateTime ChangedDate { get; set; }
		[JsonProperty(PropertyName = "last_sync")]
		public DateTime LastSync { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
