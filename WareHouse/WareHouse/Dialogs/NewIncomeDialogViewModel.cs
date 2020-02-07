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
using WareHouse.Models.ViewModels;

namespace WareHouse.Dialogs
{
	public class NewIncomeDialogViewModel : DialogViewModelBase
	{
		IncomeViewModels returnResult = null;
		#region Fields
		private ObservableCollection<ProviderTable> providerItemCollection;
		private ObservableCollection<IncomeItem> incomeItemCollection;
		private ObservableCollection<Product> productProvider;
		private ObservableCollection<WareHouseTable> wareHouseProvider;
		private DateTime selectedDate;
		private double total;
		private ProviderTable selectedProvider;
		#endregion
		#region Properties
		public ObservableCollection<ProviderTable> ProviderItemCollection { get => providerItemCollection; set { providerItemCollection = value; RaisePropertyChanged(); } }
		public ObservableCollection<IncomeItem> IncomeItemCollection
		{
			get => incomeItemCollection; set
			{

				incomeItemCollection = value; RaisePropertyChanged();
			}
		}
		public DateTime SelectedDate { get => selectedDate; set { selectedDate = value; RaisePropertyChanged(); } }
		public double Total { get => total; set { total = value; RaisePropertyChanged(); } }
		public ObservableCollection<Product> ProductProvider { get => productProvider; set { productProvider = value; RaisePropertyChanged(); } }
		public ObservableCollection<WareHouseTable> WareHouseProvider { get => wareHouseProvider; set { wareHouseProvider = value; RaisePropertyChanged(); } }
		public ProviderTable SelectedProvider { get => selectedProvider; set { selectedProvider = value; RaisePropertyChanged(); } }
		#endregion

		#region Commands
		public DelegateCommand AddToCollectionCommand { get; private set; }
		#endregion


		public NewIncomeDialogViewModel()
		{
			AddToCollectionCommand = new DelegateCommand(InsertNewItemToCollection);
			IncomeItemCollection = new ObservableCollection<IncomeItem>();
			IncomeItemCollection.CollectionChanged += IncomeItemCollection_CollectionChanged;
		}

		private void IncomeItemCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			
		}

		public override void OnDialogOpened(IDialogParameters parameters)
		{
			returnResult = parameters.GetValue<IncomeViewModels>("model");
			ProductProvider = new ObservableCollection<Product>(returnResult.Products);
			WareHouseProvider = new ObservableCollection<WareHouseTable>(returnResult.WareHouses);
			ProviderItemCollection = new ObservableCollection<ProviderTable>(returnResult.Providers);
		}


		private void InsertNewItemToCollection()
		{
			IncomeItemCollection.Add(new IncomeItem());
		}

		protected override void CloseDialogOnOk(IDialogParameters parameters)
		{
			if (SelectedProvider == null)
			{
				MessageBox.Show("Для сохранения выберите поставщика");
				return;
			}
			Result = ButtonResult.OK;
			if (parameters == null) parameters = new DialogParameters();
			returnResult.Date = SelectedDate;
			returnResult.IncomeItems = IncomeItemCollection;
			returnResult.Total = Total;
			returnResult.SelectedProviderId = selectedProvider.Id;
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
