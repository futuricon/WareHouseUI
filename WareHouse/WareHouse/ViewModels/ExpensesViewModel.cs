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
	public class ExpensesViewModel :BindableBase
	{
		#region Command
		public DelegateCommand OpenNewDialogCommand { get; private set; }
		#endregion
		#region Field
		bool IsActive = true;
		IDialogService _dialogService;
		IExpenseRepository _expenseRepository;
		private ObservableCollection<Expense> _expenseCollection;
		#endregion
		#region Properties
		public ObservableCollection<Expense> ExpenseCollection { get => _expenseCollection; set { _expenseCollection = value; RaisePropertyChanged(); } }
		public ILogger Logger { get; }
		#endregion

		public ExpensesViewModel(ILogger logger,IDialogService dialogService, IExpenseRepository expenseRepository)
		{
			Logger = logger;
			_dialogService = dialogService;
			_expenseRepository = expenseRepository;
			OpenNewDialogCommand = new DelegateCommand(OpenDialog);
			ExpenseCollection =new ObservableCollection<Expense>(expenseRepository.GetAll());
		}
		private void OpenDialog()
		{
			if (!IsActive) return;
			IsActive = false;
			Logger.Information("OpenNewExpenseDialog clicked");			
			_dialogService.ShowModal("NewExpensesDialog", (x) =>
			{
				if (x.Result == ButtonResult.OK && x.Parameters != null)
				{
					var model = x.Parameters.GetValue<Expense>("model");
					Logger.Information("Trying create new expense ");
					var result = Task.Run<Expense>(async () =>
					{
						try
						{
							//ПОКА ДЛЯ WAREOUSE ВОЗМЕМ ПЕРВЫЙ ПОПАВШИЙСЯ 
							var target = new Expense
							{
								ChangedDate = DateTime.Now,
								Date = DateTime.Now,
								Amount=model.Amount,
								Comment=model.Comment
							};

							await _expenseRepository.Create(target);
							Logger.Information("Expense created successfully");
							return target;
						}
						catch (Exception ex)
						{
							Logger.Error("ex.Message", ex.Message);
							Logger.Error("Inner exception", ex.InnerException.Message + " ");
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

		private void AddNewToCollection(Expense result)
		{
			ExpenseCollection.Add(result);
		}
	}
}
