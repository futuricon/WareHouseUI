using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class Product
	{
        public Product()
        {
            Incomes = new List<Income>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        [JsonProperty(PropertyName = "cost_price")]
        public double CostPrice { get; set; }

        public double Count { get; set; }
        public string BarCode { get; set; }


        [JsonProperty(PropertyName = "changed_date")]
        public DateTime ChangedDate { get; set; }
        [JsonProperty(PropertyName = "last_sync")]
        public DateTime LastSync { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int WareHouseId { get; set; }
        public WareHouseTable WareHouse { get; set; }

        public ICollection<Income> Incomes { get; set; }
    }
}
