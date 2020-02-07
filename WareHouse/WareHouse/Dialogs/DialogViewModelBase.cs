using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WareHouse.Dialogs
{
	public class DialogViewModelBase : BindableBase, IDialogAware
	{
		public ButtonResult  Result { get; set; }
		public string Title => string.Empty;
		private DelegateCommand<IDialogParameters> _closeDialogCancelCommand;
		private DelegateCommand<IDialogParameters> _closeDialogOkCommand;

		public DelegateCommand<IDialogParameters> CloseDialogCancelCommand =>
			_closeDialogCancelCommand ?? (_closeDialogCancelCommand = new DelegateCommand<IDialogParameters>(CloseDialogOnCancel));

		public DelegateCommand<IDialogParameters> CloseDialogOkCommand =>
			_closeDialogOkCommand ?? (_closeDialogOkCommand = new DelegateCommand<IDialogParameters>(CloseDialogOnOk));

		public virtual DelegateCommand<KeyEventArgs> KeyUpEventCommand { get; protected set; }


		public DialogViewModelBase()
		{
			KeyUpEventCommand = new DelegateCommand<KeyEventArgs>(KeyUpEventHandler);
		}
		protected virtual void KeyUpEventHandler(KeyEventArgs key)
		{
			if (key.Key == Key.Escape)
			{
				CloseDialogOnCancel(null);
			}
			if (key.Key == Key.Enter)
			{
				CloseDialogOnOk(null);
			}
		}

		protected virtual void CloseDialogOnCancel(IDialogParameters parameters)
		{
			Result = ButtonResult.Cancel;

			CloseDialog(parameters);
		}

		protected virtual void CloseDialogOnOk(IDialogParameters parameters)
		{
			Result = ButtonResult.OK;
			CloseDialog(parameters);
		}

		public event Action<IDialogResult> RequestClose;

		public bool CanCloseDialog()
		{
			return true;
		}

		public void OnDialogClosed()
		{		
		}

		public void CloseDialog(IDialogParameters parameters)
		{
			RequestClose?.Invoke(new DialogResult(Result, parameters));
		}

		public virtual void OnDialogOpened(IDialogParameters parameters)
		{

		}
	}
}
