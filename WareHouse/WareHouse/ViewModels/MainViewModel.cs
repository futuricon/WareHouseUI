using Prism.Commands;
using Prism.Regions;
using Serilog;
using System;
using WareHouse.Models.Context;
using WareHouse.Models.Infrastructure;
using WareHouse.Models.Repositories;
using WareHouse.Regions;
using WareHouse.ViewModels.ViewModelBase;
using WareHouse.Views;
namespace WareHouse.ViewModels
{
	public class MainViewModel : MainViewBase
	{
		private readonly ISynchronizeFactory synchronizeFactory;

		public ILogger Logger { get; }

		public MainViewModel(IConfigurationHelper helper, ISynchronizeFactory synchronizeFactory,ILogger logger,IRegionManager regionManager, SeedData data) 
			:base(helper, regionManager)
		{
			//data.SetExpense();
			this.synchronizeFactory = synchronizeFactory;
			Logger = logger;

			InitializeCommand();
			InitializeViews();
		}

		private async void Synchronize()
		{

			//string json = "{\"title\":\"test\"," +
			//			  "\"description\":\"test\"," +
			//			  "\"full_text\":\"test\"," +
			//			  "\"category\":4}";

			//var test = new { title = "A", description = "B", full_text = "C", category = 2 };
			//var test2 = new { title = "AA", description = "BB", full_text = "CC", category = 3 };

			//IEnumerable<object> t = new List<object> { test,test2 };
			//await synchronizeFactory.BeginSynchronizeAsync(Url, MethodType.POST, t);



			//var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			//httpWebRequest.ContentType = "application/json";
			//httpWebRequest.Method = "POST";

			//using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			//{
			//	string json = "{\"title\":\"test\"," +
			//				  "\"description\":\"test\"," +
			//				  "\"full_text\":\"test\"," +
			//				  "\"category\":4}";

			//	streamWriter.Write(json);
			//}

			//var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			//using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			//{
			//	var result = streamReader.ReadToEnd();
			//}

		}
		

		//private void KeyUpEventHandler(KeyEventArgs key)
		//{
		//	if (key == null) return;
		//	if (key.Key == Key.Enter)
		//	{
		//		if (ProductProvider.FilteredProducts == null || ProductProvider.FilteredProducts.Count() == 0) return;

		//		SelectedItem = ProductProvider.FilteredProducts.FirstOrDefault();
		//		IsDropDownOpen = false;
		//	}
		//}

	
		private void InitializeCommand()
		{
			WareHouseCommand = new DelegateCommand(OpenWareHouseView);
			//PreviewKeyDownCommand = new DelegateCommand<KeyEventArgs>(KeyUpEventHandler);
			SendRequestCommand = new DelegateCommand(Synchronize);
			IncomeCommand = new DelegateCommand(OpenIncomeView);
			RealizationCommand = new DelegateCommand(OpenRealizationView);
			ExpenseCommand = new DelegateCommand(OpenExpenseView);
			ProviderCommand = new DelegateCommand(OpenProviderView);
			ClientCommand = new DelegateCommand(OpenClientView);
			ReturnCommand = new DelegateCommand(OpenReturnView);
			ProductCommand = new DelegateCommand(OpenProductView);
		}

		private void OpenProductView()
		{
			OpenViewBase(_productView, nameof(ProductView));
		}

		private void OpenReturnView()
		{
			OpenViewBase(null, null);
		}

		private void OpenClientView()
		{
			OpenViewBase(_clientView, nameof(ClientView));
		}

		private void OpenProviderView()
		{
			OpenViewBase(_providerView, nameof(ProviderView));
		}

		#region CommandRealization

		private void OpenWareHouseView()
		{
			OpenViewBase(_wareHouseView, nameof(WareHouseView));
		}	

		private void OpenExpenseView()
		{
			OpenViewBase(_expensesView, nameof(ExpensesView));
		}

		private void OpenRealizationView()
		{
			OpenViewBase(_realizationView, nameof(RealizationView));
		}

		private void OpenIncomeView()
		{
			OpenViewBase(_incomeView, nameof(IncomeView));
		}
		#endregion

		private void InitializeViews()
		{
			_wareHouseView = new WareHouseView();
			_expensesView = new ExpensesView();
			_incomeView = new IncomeView();
			_realizationView = new RealizationView();
			_clientView = new ClientView();
			_providerView = new ProviderView();
			_productView = new ProductView();
		}

		private void OpenViewBase(object view, string viewName, string regionName = RegionHelper.mainRegionName)
		{
			RegionManager.Regions[regionName].RemoveAll();
			Logger.Information("Remove all region WareHouse");
			if (view == null) return;
			RegionManager.Regions[regionName].Add(view);
			Logger.Information("Load view, name {0}", viewName);
		}

	}
}
