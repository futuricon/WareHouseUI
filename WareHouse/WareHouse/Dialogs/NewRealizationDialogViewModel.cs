using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WareHouse.Models.DbModels;
using WareHouse.Models.ViewModels;

namespace WareHouse.Dialogs
{
	class NewRealizationDialogViewModel : DialogViewModelBase
	{
		OrderViewModel returnResult = null;
		#region Fields
		private ObservableCollection<Client> clientProviderCollection;
		private ObservableCollection<OrderItem> orderItemCollection;
		private ObservableCollection<Product> productProvider;
		private ObservableCollection<WareHouseTable> wareHouseProvider;
		private DateTime selectedDate;
		private double total;
		private Client selectedClient;
		#endregion
		#region Properties
		public ObservableCollection<Client> ClientProvider { get => clientProviderCollection; set { clientProviderCollection = value; RaisePropertyChanged(); } }
		public ObservableCollection<OrderItem> OrderItemCollection
		{
			get => orderItemCollection; set
			{

				orderItemCollection = value; RaisePropertyChanged();
			}
		}
		public DateTime SelectedDate { get => selectedDate; set { selectedDate = value; RaisePropertyChanged(); } }
		public double Total { get => total; set { total = value; RaisePropertyChanged(); } }
		public ObservableCollection<Product> ProductProvider { get => productProvider; set { productProvider = value; RaisePropertyChanged(); } }
		public ObservableCollection<WareHouseTable> WareHouseProvider { get => wareHouseProvider; set { wareHouseProvider = value; RaisePropertyChanged(); } }
		public Client SelectedClient { get => selectedClient; set { selectedClient = value; RaisePropertyChanged(); } }
		#endregion

		#region Commands
		public DelegateCommand AddToCollectionCommand { get; private set; }
		#endregion


		public NewRealizationDialogViewModel()
		{
			AddToCollectionCommand = new DelegateCommand(InsertNewItemToCollection);
			OrderItemCollection = new ObservableCollection<OrderItem>();
		}

		public override void OnDialogOpened(IDialogParameters parameters)
		{
			returnResult = parameters.GetValue<OrderViewModel>("model");
			ProductProvider = new ObservableCollection<Product>(returnResult.Products);
			WareHouseProvider = new ObservableCollection<WareHouseTable>(returnResult.WareHouses);
			ClientProvider = new ObservableCollection<Client>(returnResult.Client);
		}


		private void InsertNewItemToCollection()
		{
			OrderItemCollection.Add(new OrderItem());
		}

		protected override void CloseDialogOnOk(IDialogParameters parameters)
		{
			if (SelectedClient == null)
			{
				MessageBox.Show("Для сохранения выберите клиента");
				return;
			}
			Result = ButtonResult.OK;
			if (parameters == null) parameters = new DialogParameters();
			returnResult.Date = SelectedDate;
			returnResult.OrderItems = OrderItemCollection;
			returnResult.Total = Total;
			returnResult.SelectedClientId = SelectedClient.Id;
			parameters.Add("model", returnResult);
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
