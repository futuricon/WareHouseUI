using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Dialogs
{
	public class DialogDiliverClientViewModel : DialogViewModelBase
	{
		private string dialogText;
		private string fIO;
		private string phoneNumber;

		public string DialogText { get => dialogText; set { dialogText = value; RaisePropertyChanged(); } }
		public string FIO { get => fIO; set { fIO = value; RaisePropertyChanged(); } }
		public string PhoneNumber { get => phoneNumber; set { phoneNumber = value; RaisePropertyChanged(); } }

		public override void OnDialogOpened(IDialogParameters parameters)
		{
			if (parameters != null)
			{
				DialogText = parameters.GetValue<string>("DialogText");
				FIO = parameters.GetValue<string>("FIO");
				PhoneNumber = parameters.GetValue<string>("PhoneNumber");
			}
		}

		protected override void CloseDialogOnOk(IDialogParameters parameters)
		{
			Result = ButtonResult.OK;
			if (parameters == null) parameters = new DialogParameters();
			parameters.Add("FIO", FIO);
			parameters.Add("PhoneNumber", PhoneNumber);
			CloseDialog(parameters);

		}
	}
}
