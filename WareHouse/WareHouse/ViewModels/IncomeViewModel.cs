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
using WareHouse.Models.Repositories;
using WareHouse.Models.ViewModels;

namespace WareHouse.ViewModels
{
	public class IncomeViewModel : BindableBase
	{
		#region Command
		public DelegateCommand OpenNewDialogCommand { get; private set; }
        #endregion
        IIncomeRepository _incomeRepository;
		IWareHouseRepository _wareHouseRepository;
		IProductRepository _productRepository;
		IProviderRepository _providerRepository;
		bool IsActive = true;
		IDialogService _dialogService;

		private ObservableCollection<Income> incomeCollection;

        public ObservableCollection<Income> IncomeCollection { get => incomeCollection; set { incomeCollection = value; RaisePropertyChanged(); } }

		public ILogger Logger { get; }

		public IncomeViewModel(IIncomeRepository incomeRepository,
			IWareHouseRepository wareHouseRepository,
			IProviderRepository providerRepository,
			IProductRepository productRepository ,IDialogService dialogService,ILogger logger)
		{
			_providerRepository = providerRepository;
			   _incomeRepository = incomeRepository;
			_wareHouseRepository = wareHouseRepository;
			_productRepository = productRepository;
			_dialogService = dialogService;
			Logger = logger;
			IncomeCollection = new ObservableCollection<Income>(incomeRepository.GetOrderWithRelations);
            foreach (var item in IncomeCollection)
            {
                item.Calculate();
            }
            OpenNewDialogCommand = new DelegateCommand(OpenIncomeDialog);
        }

        private void OpenIncomeDialog()
        {
			if (!IsActive) return;
			IsActive = false;
			Logger.Information("OpenNewIncomeDialog clicked");
			var model = new IncomeViewModels();
			model.WareHouses = _wareHouseRepository.GetAll().ToList();
			model.Products = _productRepository.GetAll().ToList();
			model.Providers = _providerRepository.GetAll().ToList();
			var parametrs = new DialogParameters();
			parametrs.Add("model", model);
			_dialogService.ShowModal("NewIncomeDialog", parametrs, (x) =>
			{
				if (x.Result == ButtonResult.OK && x.Parameters != null)
				{
					var model = x.Parameters.GetValue<IncomeViewModels>("model");
					Logger.Information("Trying create new income ");
					var result = Task.Run<Income>(async () =>
					{
						try
						{
							//ПОКА ДЛЯ WAREOUSE ВОЗМЕМ ПЕРВЫЙ ПОПАВШИЙСЯ 
							var target = new Income
							{
								ChangedDate = DateTime.Now,
								Date = DateTime.Now,
								IncomeItemCollection = model.IncomeItems, 
								Total = model.Total,
								ProviderTableId =model.SelectedProviderId
							};
							
							await _incomeRepository.Create(target);
							Logger.Information("Income created successfully");
							return target;
						}
						catch (Exception ex)
						{
							Logger.Error("ex.Message", ex.Message);
							Logger.Error("Inner exception", ex.InnerException.Message +" ");
							Logger.Error("Can not create Income ");
							return null;
						}
					});
					if (result?.Result != null)
					{
						AddNewToCollection(result.Result);
					}
				}
			});

			IsActive = true;
		}
		public void AddNewToCollection(Income income)
		{
			//вызов медота calculate посчитает нам count
			income.Calculate();
			IncomeCollection.Add(income);
		}
	}
}
