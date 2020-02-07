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
	public class ProviderViewModel : BindableBase
	{
		#region Fields
		private ObservableCollection<ProviderTable> providerCollection;
		IDialogService _dialogService;
		IProviderRepository _providerRepository;
		#endregion
		#region Command
		public DelegateCommand OpenNewDialogCommand { get; private set; }
		#endregion
		#region Collections
		public ObservableCollection<ProviderTable> ProviderCollection { get => providerCollection; set { providerCollection = value; RaisePropertyChanged(); } }

		#endregion
		#region Properties
		public bool IsActive { get; private set; } = true;
		public ILogger Logger { get; }
		#endregion

		public ProviderViewModel(IDialogService dialogService, IProviderRepository providerRepository, ILogger logger)
		{
			Logger = logger;
			_dialogService = dialogService;
			_providerRepository = providerRepository;
			OpenNewDialogCommand = new DelegateCommand(OpenDialog);
			Task.Run(async () => await LoadProviders());
		}

		public void OpenDialog()
		{
			if (!IsActive) return;
			IsActive = false;

			Logger.Information("NewProviderDialog clicked");
			_dialogService.ShowModal("NewProviderDialog", (x) =>
			{
				if (x.Result == ButtonResult.OK && x.Parameters != null)
				{
					var fio = x.Parameters.GetValue<string>("FIO");
					var phoneNumber = x.Parameters.GetValue<string>("PhoneNumber");

					Logger.Information("Trying create new provider name is {0} phone is {1}", fio, phoneNumber);
					var result = Task.Run(async () =>
					{
						try
						{
							var target = new ProviderTable { ChangedDate = DateTime.Now, FIO = fio, PhoneNumber = phoneNumber };
							await _providerRepository.Create(target);
							Logger.Information("Provider created successfully FIO is {0} ,PhoneNumber is {1}", fio, phoneNumber);
							return target;
						}
						catch (Exception ex)
						{
							Logger.Error("ex.Message", ex.Message);
							Logger.Error("Inner exception", ex.InnerException);
							Logger.Error("Can not create Provider FIO is {0} ,PhoneNumber is {1}", fio, phoneNumber);
							return null;
						}
					});
					if (result?.Result != null)
					{
						AddNewProviderToCollection(result.Result);
					}
				}
			});

			IsActive = true;
		}
		public async Task LoadProviders() => await Task.Run(() =>
		{
			ProviderCollection = new ObservableCollection<ProviderTable>(_providerRepository.GetAll());
		});

		public void AddNewProviderToCollection(ProviderTable provider)
		{
			ProviderCollection.Add(provider);
		}
	}
}
