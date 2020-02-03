using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class IncomeItem
	{
		
		public int Id { get; set; }
		public double Price { get; set; }
		public double Count { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

		public ICollection<IncomeItemIncome> IncomeItemCollection { get; set; }

	}
}
