using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class Income
	{
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "changed_date")]
        public DateTime ChangedDate { get; set; }
        [JsonProperty(PropertyName = "last_sync")]
        public DateTime LastSync { get; set; }
        public int WareHouseId { get; set; }
        public WareHouseTable WareHouse { get; set; }

        public ICollection<IncomeItemIncome> IncomeItemCollection { get; set; }
    }
}
