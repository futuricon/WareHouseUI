using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.ViewModels
{
	public class MainViewBase :BindableBase
	{
		private readonly string url = "http://85.143.175.111:2242/posts/";

		public string Url { get; set; }
		#region Commands
		public virtual DelegateCommand<KeyEventArgs> PreviewKeyDownCommand { get; protected set; }
		public virtual DelegateCommand SendRequestCommand { get; protected set; }
		public virtual DelegateCommand<Grid> CloseMenuCommand { get; private set; }
		public virtual DelegateCommand<Grid> OpenMenuCommand { get; private set; }
		#endregion
		#region Fields
		private bool _IsDropDownOpen = false;
		private string _searchingText;
		private Product _selectedItem;
		private Visibility _buttonOpenMenuVisibility = Visibility.Hidden;
		private Visibility _buttonCloseMenuVisibility = Visibility.Visible;

		#endregion
		#region Properties

		public bool IsDropDownOpen
		{
			get { return _IsDropDownOpen; }
			set { _IsDropDownOpen = value; RaisePropertyChanged(); }
		}

		public string SearchingText
		{
			get { return _searchingText; }
			set
			{
				_searchingText = value;
				RaisePropertyChanged();
			}

		}

		public Product SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;
				RaisePropertyChanged();
			}
		}

		public Visibility ButtonOpenMenuVisibility
		{
			get { return _buttonOpenMenuVisibility; }
			set { _buttonOpenMenuVisibility = value; RaisePropertyChanged(); }
		}


		public Visibility ButtonCloseMenuVisibility
		{
			get { return _buttonCloseMenuVisibility ; }
			set { _buttonCloseMenuVisibility = value; RaisePropertyChanged(); }
		}


		#endregion

		public MainViewBase(IConfigurationHelper configuration)
		{
			Url = configuration.Url;
			if (string.IsNullOrWhiteSpace(Url))
				Url = url;
			CloseMenuCommand = new DelegateCommand<Grid>(CloseMenu);
			OpenMenuCommand = new DelegateCommand<Grid>(OpenMenu);
		}

		private void OpenMenu(Grid grid)
		{
			ButtonCloseMenuVisibility = Visibility.Visible;
			ButtonOpenMenuVisibility = Visibility.Collapsed;
			grid.ColumnDefinitions[0].Width = new GridLength(225);
		}

		private void CloseMenu(Grid grid)
		{
			ButtonCloseMenuVisibility = Visibility.Collapsed;
			ButtonOpenMenuVisibility = Visibility.Visible;
			grid.ColumnDefinitions[0].Width = new GridLength(70);
		}
	}
}
