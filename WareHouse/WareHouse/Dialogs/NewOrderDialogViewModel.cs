using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Dialogs
{
	public class NewOrderDialogViewModel : DialogViewModelBase
	{
		public string WareHouseName { get; set; }

		public NewOrderDialogViewModel()
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
