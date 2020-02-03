using Prism.Commands;
using Prism.Mvvm;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WareHouse.Models.Context;
using WareHouse.Models.Infrastructure;
using WareHouse.Models.Provider;
using WpfControls;
using WpfControls.Editors;
namespace WareHouse.ViewModels
{
	public class MainViewModel : MainViewBase
	{
		private readonly ISynchronizeFactory synchronizeFactory;

		public ILogger Logger { get; }

		public MainViewModel(IConfigurationHelper helper, ISynchronizeFactory synchronizeFactory,ILogger logger) :base(helper)
		{
			PreviewKeyDownCommand = new DelegateCommand<KeyEventArgs>(KeyUpEventHandler);
			SendRequestCommand = new DelegateCommand(Synchronize);
			this.synchronizeFactory = synchronizeFactory;
			Logger = logger;
			//Synchronize();
		}

		private async void Synchronize()
		{

			//string json = "{\"title\":\"test\"," +
			//			  "\"description\":\"test\"," +
			//			  "\"full_text\":\"test\"," +
			//			  "\"category\":4}";

			//var test = new { title = "A", description = "B", full_text = "C", category = 2 };
			//var test2 = new { title = "AA", description = "BB", full_text = "CC", category = 3 };

			//IEnumerable<object> t = new List<object> { test,test2 };
			//await synchronizeFactory.BeginSynchronizeAsync(Url, MethodType.POST, t);



			//var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			//httpWebRequest.ContentType = "application/json";
			//httpWebRequest.Method = "POST";

			//using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			//{
			//	string json = "{\"title\":\"test\"," +
			//				  "\"description\":\"test\"," +
			//				  "\"full_text\":\"test\"," +
			//				  "\"category\":4}";

			//	streamWriter.Write(json);
			//}

			//var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			//using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			//{
			//	var result = streamReader.ReadToEnd();
			//}

		}
		

		private void KeyUpEventHandler(KeyEventArgs key)
		{
			if (key == null) return;
			if (key.Key == Key.Enter)
			{
				if (ProductProvider.FilteredProducts == null || ProductProvider.FilteredProducts.Count() == 0) return;

			SelectedItem = ProductProvider.FilteredProducts.FirstOrDefault();
				IsDropDownOpen = false;
			}
		}

		

	

	}
}
