using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class Client : IEntity
	{
		public Client()
		{
			Orders = new List<Order>();
			Incomes = new List<Income>();
		}
		public int Id { get; set; }
		public double Balance { get; set; }
		public string FIO { get; set; }
		public string PhoneNumber { get; set; }
		[JsonProperty(PropertyName ="changed_date")]
		public DateTime ChangedDate { get; set; }
		[JsonProperty(PropertyName = "last_sync")]
		public DateTime? LastSync { get; set; }

		public ICollection<Order> Orders { get; set; }
		public ICollection<Income> Incomes { get; set; }
	}
}
