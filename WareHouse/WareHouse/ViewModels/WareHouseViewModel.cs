using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Dialogs;
using WareHouse.Models.DbModels;
using WareHouse.Models.Repositories;

namespace WareHouse.ViewModels
{
	public class WareHouseViewModel : BindableBase
	{
		#region Commands
		public virtual DelegateCommand OpenNewDialogCommand { get; protected set; }
		#endregion

		#region Fields
		private ObservableCollection<WareHouseTable> wareHouseCollection;
		IWareHouseRepository _wareHouseRepository;
		IDialogService _dialogService;
		#endregion
		#region Collections
		public ObservableCollection<WareHouseTable> WareHouseCollection { get => wareHouseCollection; set { wareHouseCollection = value; RaisePropertyChanged(); } }

		public bool IsActive { get; private set; } = true;
		public ILogger Logger { get; }
		#endregion

		public WareHouseViewModel(IWareHouseRepository wareHouseRepository, ILogger logger, IDialogService dialogService)
		{
			_wareHouseRepository = wareHouseRepository;
			Logger = logger;
			_dialogService = dialogService;
			OpenNewDialogCommand = new DelegateCommand(OpenNewWareHouse);
			Task.Run(async () => { await LoadWareHousesAsync(); });
		}

		public void OpenNewWareHouse()
		{
			if (!IsActive) return;
			IsActive = false;
			Logger.Information("OpenNewWareHouse clicked");
			_dialogService.ShowModal("NewWareHouseDialog", (x) =>
			{
				if (x.Result == ButtonResult.OK && x.Parameters != null)
				{
					var name = x.Parameters.GetValue<string>("WareHouseName");
					if (name == null)
					{
						Logger.Information("WareHouse name is empty");
					}
					else
					{
						Logger.Information("Trying create new warehouse name is {0}", name);
						var result = Task.Run<WareHouseTable>(async () =>
						{
							try
							{
								var target = new WareHouseTable { Status = true, Title = name };
								await _wareHouseRepository.Create(target);
								Logger.Information("Warehouse created successfully name is {0}", name);
								return target;
							}
							catch (Exception ex)
							{
								Logger.Error("ex.Message", ex.Message);
								Logger.Error("Inner exception", ex.InnerException);
								Logger.Error("Can not create warehouse name is {0}", name);
								return null;
							}
						});
						if (result?.Result != null)
						{
							AddNewToCollection(result.Result);
						}
					}
				}
			});

			IsActive = true;
		}

		public async Task LoadWareHousesAsync()
		{
			WareHouseCollection = new ObservableCollection<WareHouseTable>(_wareHouseRepository.GetAll());
			foreach (var wh in WareHouseCollection)
			{
				wh.CalculateBalance();
			}
			RaisePropertyChanged("WareHouseCollection");
		}
		public void AddNewToCollection(WareHouseTable wareHouseTable)
		{
			WareHouseCollection.Add(wareHouseTable);
		}
	}
}
