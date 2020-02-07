using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Dialogs
{
	public static class DialogExtension
	{
        public static void ShowModal(this IDialogService dialogService, string dialogViewName, string message, Action<IDialogResult> callBack)
        {
            dialogService.ShowDialog(dialogViewName, new DialogParameters($"message={message}"), callBack);
        }

        public static void ShowModal(this IDialogService dialogService, string dialogViewName, IDialogParameters dialogParameters, Action<IDialogResult> callBack)
        {
            dialogService.ShowDialog(dialogViewName, dialogParameters, callBack);
        }
        public static void ShowModal(this IDialogService dialogService, string dialogViewName,Action<IDialogResult> callBack)
        {
            dialogService.ShowDialog(dialogViewName, null, callBack);
        }
    }
}
