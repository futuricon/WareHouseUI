using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WareHouse.Models.DbModels
{
	[Table("Providers")]
	public class ProviderTable : IEntity
	{
		public ProviderTable()
		{
			Incomes = new List<Income>();
		}
		public int Id { get; set; }
		public string FIO { get; set; }
		public string PhoneNumber { get; set; }
		public double Balance { get; set; }
		[JsonProperty(PropertyName = "changed_date")]
		public DateTime ChangedDate { get; set; }
		[JsonProperty(PropertyName = "last_sync")]
		public DateTime? LastSync { get; set; }

		public ICollection<Income> Incomes { get; set; }

	}
}
