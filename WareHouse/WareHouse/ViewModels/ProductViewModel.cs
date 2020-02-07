using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Dialogs;
using WareHouse.Models.DbModels;
using WareHouse.Models.Infrastructure;
using WareHouse.Models.Repositories;
using WareHouse.Models.ViewModels;

namespace WareHouse.ViewModels
{
	public class ProductViewModel :BindableBase
	{
		#region Fields
		private ObservableCollection<Product> productCollection;
		IDialogService _dialogService;
		IWareHouseRepository _wareHouseRepository;
		IProductRepository _productRepository;
		ICategoryRepository _categoryRepository;
		#endregion
		#region Command
		public DelegateCommand OpenNewDialogCommand { get; private set; }
		public DelegateCommand<Product> UpdateProductCommand { get; private set; }	
		#endregion
		#region Collections
		public ObservableCollection<Product> ProductCollection { get => productCollection; set { productCollection = value; RaisePropertyChanged(); } }

		#endregion
		#region Properties
		public bool IsActive { get; private set; } = true;
		public ILogger Logger { get; }
		#endregion

		public ProductViewModel(IDialogService dialogService, IWareHouseRepository wareHouseRepository,IProductRepository productRepository, ILogger logger,
			ICategoryRepository categoryRepository)
		{
			Logger = logger;
			_dialogService = dialogService;
			_wareHouseRepository = wareHouseRepository;
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
			OpenNewDialogCommand = new DelegateCommand(OpenDialog);
			UpdateProductCommand = new DelegateCommand<Product>(OpenDialog);
			Task.Run(async () => await LoadProduct());
		}

		private void OpenDialog(Product product)
		{
			IDialogParameters parameters = new DialogParameters();
			DialogHelper dialogHelper = new DialogHelper
			{
				CategoryRepository = _categoryRepository,
				DialogService = _dialogService,
				WareHouseRepository = _wareHouseRepository,
				Product = product
			};
			var wareHouse = product.WareHouse;
			var categry = product.Category;
			parameters.Add("repo", dialogHelper);
			Logger.Information("NewProductDialog clicked");
			_dialogService.ShowModal("NewProductDialog", parameters, (x) =>
			{
				if (x.Result == ButtonResult.OK && x.Parameters != null)
				{
					var product = x.Parameters.GetValue<Product>("model");
					Logger.Information("Trying update product name is {0} warehouseid {1} categoryid {2},price {3},count {4}",
						product.Title, product.WareHouseId, product.Price, product.Count);
					var result = Task.Run(async () =>
					{
						product.ChangedDate = DateTime.Now;
						try
						{
							product.WareHouse = null;
							product.Category = null;

							   await _productRepository.Update(product);
							Logger.Information("Product updated successfully name is {0} warehouseid {1} categoryid {2},price {3},count {4}",
							product.Title, product.WareHouseId, product.Price, product.Count);

							return product;
						}
						catch (Exception ex)
						{
							Logger.Error("ex.Message", ex.Message);
							Logger.Error("Inner exception", ex.InnerException);
							Logger.Information("Can not update product name is {0} warehouseid {1} categoryid {2},price {3},count {4}",
							product.Title, product.WareHouseId, product.Price, product.Count);
							return null;
						}
					});
					if (result?.Result != null)
					{
						product.WareHouse = wareHouse;
						product.Category = categry;
						UpdateCollection(result.Result);
					}
				}
			});
		}

		private void UpdateCollection(Product result)
		{
			if(ProductCollection.AnyIndex(x=>x.Id==result.Id,out int index))
			{
				ProductCollection[index] = result;
			}
		}

		public void OpenDialog()
		{
			//if (!IsActive) return;
			//IsActive = false;
			IDialogParameters parameters = new DialogParameters();
			DialogHelper dialogHelper = new DialogHelper
			{
				CategoryRepository = _categoryRepository,
				DialogService = _dialogService,
			//	ProductRepository = _productRepository,
				WareHouseRepository= _wareHouseRepository
			};
			parameters.Add("repo", dialogHelper);
			Logger.Information("NewProductDialog clicked");
			_dialogService.ShowModal("NewProductDialog", parameters, (x) =>
			{
				if (x.Result == ButtonResult.OK && x.Parameters != null)
				{
					var product = x.Parameters.GetValue<Product>("model");
					Logger.Information("Trying create new product name is {0} warehouseid {1} categoryid {2},price {3},count {4}", 
						product.Title, product.WareHouseId,product.Price,product.Count);
					var result = Task.Run(async () =>
					{
						product.ChangedDate = DateTime.Now;
						try
						{
							await _productRepository.Create(product);
							Logger.Information("Product created successfully name is {0} warehouseid {1} categoryid {2},price {3},count {4}",
							product.Title, product.WareHouseId, product.Price, product.Count);

							return product;
						}
						catch (Exception ex)
						{
							Logger.Error("ex.Message", ex.Message);
							Logger.Error("Inner exception", ex.InnerException);
							Logger.Information("Can not create product name is {0} warehouseid {1} categoryid {2},price {3},count {4}",
							product.Title, product.WareHouseId, product.Price, product.Count);
							return null;
						}
					});
					if (result?.Result != null)
					{
						AddNewProductToCollection(result.Result);
					}
				}
			});

			//IsActive = true;
		}
		public async Task LoadProduct() => await Task.Run(() =>
		{
			ProductCollection = new ObservableCollection<Product>(_productRepository.GetOrderWithRelations);
		});

		public void AddNewProductToCollection(Product product)
		{
			ProductCollection.Add(product);
		}
	}
}
