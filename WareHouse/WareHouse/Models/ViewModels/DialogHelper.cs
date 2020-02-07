using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.DbModels;
using WareHouse.Models.Repositories;

namespace WareHouse.Models.ViewModels
{
	public class DialogHelper
	{
		public IProductRepository ProductRepository { get; set; }
		public ICategoryRepository CategoryRepository { get; set; }
		public IWareHouseRepository WareHouseRepository { get; set; }
		public IDialogService DialogService { get; set; }
		public Product Product { get; set; }
	}
}
