using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WareHouse.Models.Infrastructure;
namespace WareHouse.Models.DbModels
{
	public class Category : CollectionHelper, IEntity
	{
		private string title;

		public Category()
		{
			Products = new List<Product>();
		}
		public int Id { get; set; }
		public string Title
		{
			get => title; set
			{
				title = value;
				OnUpdate(value);
				OnPropertyChanged();
			}
		}
		[JsonProperty(PropertyName = "changed_date")]
		public DateTime ChangedDate { get; set; }
		[JsonProperty(PropertyName = "last_sync")]
		public DateTime? LastSync { get; set; }

		public ICollection<Product> Products { get; set; }

	}
}
