using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class Payment
	{
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "changed_date")]
        public DateTime ChangedDate { get; set; }
        [JsonProperty(PropertyName = "last_sync")]
        public DateTime LastSync { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}
