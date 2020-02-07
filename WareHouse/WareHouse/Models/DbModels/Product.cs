using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.Infrastructure;
namespace WareHouse.Models.DbModels
{
    public class Product : NotifyChangedPropertyBase, IEntity
    {
        private WareHouseTable wareHouse;
        private Category category;

        public Product()
        {
            IncomeItems = new List<IncomeItem>();
            OrderItems = new List<OrderItem>();
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
        public DateTime? LastSync { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get => category; set { 
                category = value; OnPropertyChanged();
            } }

        public int WareHouseId { get; set; }
        public WareHouseTable WareHouse { get => wareHouse; set { wareHouse = value; OnPropertyChanged(); } }

        public ICollection<IncomeItem> IncomeItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
