using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Dialogs
{
	public class NewWareHouseDialogViewModel : DialogViewModelBase
	{
		private string wareHouseName;

		public string WareHouseName { get => wareHouseName; set { wareHouseName = value; RaisePropertyChanged(); } }

		public NewWareHouseDialogViewModel()
		{
		}

		protected override void CloseDialogOnOk(IDialogParameters parameters)
		{
			Result = ButtonResult.OK;
			if (parameters == null) parameters = new DialogParameters();
			parameters.Add("WareHouseName", WareHouseName);
			CloseDialog(parameters);

		}
	}
}
