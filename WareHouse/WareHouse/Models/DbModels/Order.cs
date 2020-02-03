using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class Order
	{
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "changed_date")]
        public DateTime ChangedDate { get; set; }
        [JsonProperty(PropertyName = "last_sync")]
        public DateTime LastSync { get; set; }
        public double Total { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<OrderItemOrder> OrderItemCollection { get; set; }
    }
}
