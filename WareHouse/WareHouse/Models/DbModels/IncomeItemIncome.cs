using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Models.DbModels
{
	public class IncomeItemIncome
	{
		public int IncomeId { get; set; }
		public Income Income { get; set; }
		public int IncomeItemId { get; set; }
		public IncomeItem IncomeItem { get; set; }
	}
}
