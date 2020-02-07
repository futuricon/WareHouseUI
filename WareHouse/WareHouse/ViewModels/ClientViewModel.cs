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
	public class ClientViewModel : BindableBase
	{
		#region Fields
		private ObservableCollection<Client> clientCollection;
		IDialogService _dialogService;
		IClientRepository _clientRepository;
		#endregion
		#region Command
		public DelegateCommand OpenNewDialogCommand { get; private set; }
		#endregion
		#region Collections
		public ObservableCollection<Client> ClientCollection { get => clientCollection; set { clientCollection = value; RaisePropertyChanged(); } }

		#endregion
		#region Properties
		public bool IsActive { get; private set; } = true;
		public ILogger Logger { get; }
		#endregion

		public ClientViewModel(IDialogService dialogService, IClientRepository clientRepository,ILogger logger)
		{
			Logger = logger;
			_dialogService = dialogService;
			_clientRepository = clientRepository;
			OpenNewDialogCommand = new DelegateCommand(OpenDialog);
			Task.Run(async () => await LoadClients());
		}

		public void OpenDialog()
		{
			if (!IsActive) return;
			IsActive = false;
			
			Logger.Information("NewClientDialog clicked");
			_dialogService.ShowModal("NewClientDialog", (x) =>
			{
				if (x.Result == ButtonResult.OK && x.Parameters != null)
				{
					var fio = x.Parameters.GetValue<string>("FIO");
					var phoneNumber = x.Parameters.GetValue<string>("PhoneNumber");

					Logger.Information("Trying create new client name is {0} phone is {1}", fio, phoneNumber);
					var result =Task.Run(async () =>
					{
						try
						{
							var target = new Client { ChangedDate = DateTime.Now, FIO = fio, PhoneNumber = phoneNumber };
							await _clientRepository.Create(target);
							Logger.Information("Client created successfully FIO is {0} ,PhoneNumber is {1}", fio, phoneNumber);
							return target;
						}
						catch (Exception ex)
						{
							Logger.Error("ex.Message", ex.Message);
							Logger.Error("Inner exception", ex.InnerException);
							Logger.Error("Can not create Client FIO is {0} ,PhoneNumber is {1}", fio, phoneNumber);
							return null;
						}
					});
					if (result?.Result != null)
					{
						AddNewClientToCollection(result.Result);
					}
				}
			});

			IsActive = true;
		}
		public async Task LoadClients() => await Task.Run(() =>
		{
			ClientCollection = new ObservableCollection<Client>(_clientRepository.GetAll());
		});

		public void AddNewClientToCollection(Client client)
		{
			ClientCollection.Add(client);
		}
	}
}
