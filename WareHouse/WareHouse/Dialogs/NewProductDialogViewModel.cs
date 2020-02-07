using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WareHouse.Models.DbModels;
using WareHouse.Models.Repositories;
using WareHouse.Models.ViewModels;

namespace WareHouse.Dialogs
{
	class NewProductDialogViewModel : DialogViewModelBase
	{
		DialogHelper repository;
		#region Fields
		private Product currentProduct;
		private ObservableCollection<Category> categoryCollection;
		private ObservableCollection<WareHouseTable> wareHouseCollection;
		private WareHouseTable selectedWareHouse;
		private Category selectedCategory;
		private string title;
		private double price;
		private double count;
		private double countBox;
		#endregion
		#region Properties		
		public WareHouseTable SelectedWareHouse { get => selectedWareHouse; set { selectedWareHouse = value; RaisePropertyChanged(); } }
		public ObservableCollection<Category> CategoryCollection { get => categoryCollection; set { categoryCollection = value; RaisePropertyChanged(); } }
		public ObservableCollection<WareHouseTable> WareHouseCollection { get => wareHouseCollection; set { wareHouseCollection = value; RaisePropertyChanged(); } }
		public Category SelectedCategory { get => selectedCategory; set { selectedCategory = value; RaisePropertyChanged(); } }
		public string TitleProduct { get => title; set { title = value; RaisePropertyChanged(); } }
		public double Price { get => price; set { price = value; RaisePropertyChanged(); } }
		public double Count { get => count; set { count = value; RaisePropertyChanged(); } }
		public double CountBox { get => countBox; set { countBox = value; RaisePropertyChanged(); } }
		#endregion
		#region Command
		public DelegateCommand OpenCategoryCommand { get; private set; }
		#endregion
		public NewProductDialogViewModel()
		{
			OpenCategoryCommand = new DelegateCommand(OpenCategoryDialog);
		}

		private void OpenCategoryDialog()
		{
			IDialogParameters parameters = new DialogParameters();
			parameters.Add("repo", repository.CategoryRepository);
			parameters.Add("collection", CategoryCollection);

			repository.DialogService.ShowModal("NewCategoryDialog", parameters, x =>
			{
				if (x.Parameters != null)
				{
					var categories = x.Parameters.GetValue<ObservableCollection<Category>>("collection");
					CategoryCollection = categories;
				}
			});
		}

		public override void OnDialogOpened(IDialogParameters parameters)
		{
			repository = parameters.GetValue<DialogHelper>("repo");
			CategoryCollection = new ObservableCollection<Category>(repository.CategoryRepository.GetAll());
			WareHouseCollection = new ObservableCollection<WareHouseTable>(repository.WareHouseRepository.GetAll());
			if (repository.Product !=null)
			{
				TitleProduct = repository.Product.Title;
				Price = repository.Product.Price;
				Count = repository.Product.Count;
				CountBox= repository.Product.Count;
				SelectedCategory = CategoryCollection.FirstOrDefault(x => x.Id == repository.Product.CategoryId);
				SelectedWareHouse = WareHouseCollection.FirstOrDefault(x => x.Id == repository.Product.WareHouseId);
			}
		}

		protected override void CloseDialogOnOk(IDialogParameters parameters)
		{
			if (SelectedWareHouse == null)
			{
				MessageBox.Show("Для сохранения выберите склад");
				return;
			}
			if (selectedCategory == null)
			{
				MessageBox.Show("Для сохранения выберите категорию");
				return;
			}
			Result = ButtonResult.OK;
			if (parameters == null) parameters = new DialogParameters();
			var product = new Product
			{
				BarCode = "1",
				CategoryId = SelectedCategory.Id,
				CostPrice = Price,
				Price = Price,
				Count = Count,
				Title = TitleProduct,
				WareHouseId = SelectedWareHouse.Id,
			};
			if (repository.Product != null)
			{
				product.Id = repository.Product.Id;
				product.WareHouse = SelectedWareHouse;
				product.Category = SelectedCategory;
			}
				parameters.Add("model", product);
			CloseDialog(parameters);
		}

		protected override void KeyUpEventHandler(KeyEventArgs key)
		{
			if (key.Key == Key.Escape)
			{
				CloseDialogOnCancel(null);
			}
		}
	}
}
