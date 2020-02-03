using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfControls;
using System.Linq;
using System.ComponentModel;

namespace WareHouse.Views
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : Window
	{
		public MainView()
		{
			InitializeComponent();
		}


		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{
			RadioButton rb = (RadioButton)sender;

			switch (rb.Content.ToString())
			{
				case "WareHouses":
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new WareHouseView());
					break;
				case "Income":
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new IncomeView());
					break;
				case "Realization":
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new RealizationView());
					break;
				case "Return":
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new WareHouseView());
					break;
				case "Delivers":
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new WareHouseView());
					break;
				case "Clients":
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new WareHouseView());
					break;
				case "Expenses":
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new ExpensesView());
					break;
				default:
					break;
			}
		}
	}
}
