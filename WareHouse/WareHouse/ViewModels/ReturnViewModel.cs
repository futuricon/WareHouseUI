using Prism.Commands;
using Prism.Services.Dialogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WareHouse.Models.Repositories;

namespace WareHouse.ViewModels
{
	public class ReturnViewModel
	{
		#region Command
		public DelegateCommand OpenNewDialogCommand { get; private set; }
		#endregion
		#region Fileds
		//private ObservableCollection<Order> realizationCollection;
		IDialogService _dialogService;
		IOrderRepository _orderRepository;
		IWareHouseRepository _wareHouseRepository;
		IProductRepository _productRepository;
		IClientRepository _clientRepository;
		bool IsActive = true;

		#endregion
		#region Properties
		//public ObservableCollection<Order> RealizationCollection { get => realizationCollection; set { realizationCollection = value; RaisePropertyChanged(); } }

		public ILogger Logger { get; }
		#endregion

		public ReturnViewModel(IWareHouseRepository wareHouseRepository, IOrderRepository orderRepository,
			IClientRepository clientRepository,
			IProductRepository productRepository, IDialogService dialogService, ILogger logger)
		{
			_clientRepository = clientRepository;
			_orderRepository = orderRepository;
			_wareHouseRepository = wareHouseRepository;
			_productRepository = productRepository;
			_dialogService = dialogService;
			Logger = logger;

			Logger = logger;
			OpenNewDialogCommand = new DelegateCommand(OpenNewOrderItemDialog);
			//RealizationCollection = new ObservableCollection<Order>(orderRepository.GetOrderWithRelations);
			//foreach (var item in RealizationCollection)
			//{
			//	item.Calculate();
			//}
		}

		private void OpenNewOrderItemDialog()
		{
			//if (!IsActive) return;
			//IsActive = false;
			//Logger.Information("OpenNewRealizationDialog clicked");
			//var model = new OrderViewModel();
			//model.WareHouses = _wareHouseRepository.GetAll();
			//model.Products = _productRepository.GetAll();
			//model.Client = _clientRepository.GetAll();
			//var parametrs = new DialogParameters();
			//parametrs.Add("model", model);
			//_dialogService.ShowModal("NewRealizationDialog", parametrs, (x) =>
			//{
			//	if (x.Result == ButtonResult.OK && x.Parameters != null)
			//	{
			//		var model = x.Parameters.GetValue<OrderViewModel>("model");
			//		Logger.Information("Trying create new realization ");
			//		var result = Task.Run<Order>(async () =>
			//		{
			//			try
			//			{
			//				//ПОКА ДЛЯ WAREOUSE ВОЗМЕМ ПЕРВЫЙ ПОПАВШИЙСЯ 
			//				var target = new Order
			//				{
			//					ChangedDate = DateTime.Now,
			//					Date = DateTime.Now,
			//					OrderItemCollection = model.OrderItems,
			//					Total = model.Total,
			//					ClientId = model.ClientId
			//				};

			//				await _orderRepository.Create(target);
			//				Logger.Information("Realization created successfully");
			//				return target;
			//			}
			//			catch (Exception ex)
			//			{
			//				Logger.Error("ex.Message", ex.Message);
			//				Logger.Error("Inner exception", ex.InnerException.Message + " ");
			//				Logger.Error("Can not create Income ");
			//				return null;
			//			}
			//		});
			//		if (result?.Result != null)
			//		{
			//			AddNewToCollection(result.Result);
			//		}
			//	}
			//});

			//IsActive = true;
		}

		//private void AddNewToCollection(Order result)
		//{
		//	result.Calculate();
		//	RealizationCollection.Add(result);
		//}
	}
}
