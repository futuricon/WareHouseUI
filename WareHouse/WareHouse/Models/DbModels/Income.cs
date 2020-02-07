using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using WareHouse.Models.Infrastructure;

namespace WareHouse.Models.DbModels
{
    public class Income : NotifyChangedPropertyBase, IEntity
    {
        [NotMapped]
        private double count;
        [NotMapped]
        private double total;
        private ProviderTable providerTable;

        public Income()
        {
            IncomeItemCollection = new List<IncomeItem>();
        }

        public int Id { get; set; }
        public double Total { get => total; set { total = value; OnPropertyChanged(); } }
        public DateTime Date { get; set; } = DateTime.Now;
        [JsonProperty(PropertyName = "changed_date")]
        public DateTime ChangedDate { get; set; }
        [JsonProperty(PropertyName = "last_sync")]
        public DateTime? LastSync { get; set; }

        public int ProviderTableId { get; set; }
        public ProviderTable ProviderTable { get => providerTable; set { providerTable = value; OnPropertyChanged(); } }

        public IEnumerable<IncomeItem> IncomeItemCollection { get; set; }

        /// <summary>
        /// NOT MAPPED
        /// </summary>
        [NotMapped]
        public double Count { get => count; set { count = value; OnPropertyChanged(); } }

        public void Calculate()
        {
            Total = 0;
            if (IncomeItemCollection == null || IncomeItemCollection.Count() == 0) return;

            foreach (var item in IncomeItemCollection.Where(x => x != null))
            {
                Total += item.Price * item.Count;
                Count = item.Count;
            }
        }
    }
}
