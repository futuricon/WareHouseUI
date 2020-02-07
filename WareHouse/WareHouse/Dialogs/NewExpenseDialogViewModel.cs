using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WareHouse.Models.DbModels;

namespace WareHouse.Dialogs
{
	public class NewExpenseDialogViewModel : DialogViewModelBase
	{
		private DateTime date;
		private double amount;
		private string comment;

		public DateTime Date { get => date; set { date = value; RaisePropertyChanged(); } }
		public double Amount { get => amount; set { amount = value; RaisePropertyChanged(); } }
		public string Comment { get => comment; set { comment = value; RaisePropertyChanged(); } }
		public NewExpenseDialogViewModel()
		{

		}


		protected override void CloseDialogOnOk(IDialogParameters parameters)
		{
			Result = ButtonResult.OK;
			if (parameters == null) parameters = new DialogParameters();
			var result = new Expense
			{
				Amount = Amount,
				Comment = Comment,
				Date = Date
			};
			parameters.Add("model", result);
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
