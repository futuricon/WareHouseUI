using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using WareHouse.Models.Infrastructure;
namespace WareHouse.Models.DbModels
{
    public class Order : NotifyChangedPropertyBase, IEntity
    {
        private double count;
        private double total;
        private Client client;

        public Order()
        {
            OrderItemCollection = new List<OrderItem>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "changed_date")]
        public DateTime ChangedDate { get; set; }
        [JsonProperty(PropertyName = "last_sync")]
        public DateTime? LastSync { get; set; }
        public double Total { get => total; set { total = value; OnPropertyChanged(); } }

        public int ClientId { get; set; }
        public Client Client { get => client; set { client = value; OnPropertyChanged(); } }

        public IEnumerable<OrderItem> OrderItemCollection { get; set; }
        /// <summary>
        /// NOT MAPPED
        /// </summary>
        [NotMapped]
        public double Count { get => count; set { count = value; OnPropertyChanged(); } }

        public void Calculate()
        {
            Count = 0;
            if (OrderItemCollection == null || OrderItemCollection.Count() == 0) return;

            foreach (var item in OrderItemCollection.Where(x => x != null))
            {
                Total += item.Price * item.Count;
                Count = item.Count;
            }
        }
    }
}
