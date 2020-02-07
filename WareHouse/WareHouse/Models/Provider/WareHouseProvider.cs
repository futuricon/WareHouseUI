using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using WareHouse.Models.DbModels;
using WareHouse.Models.Repositories;
using WpfControls.Editors;

namespace WareHouse.Models.Provider
{
	public class WareHouseProvider: ISuggestionProvider
	{
		public IEnumerable<WareHouseTable> ListOfWareHouses { get; set; }
		public static IEnumerable<WareHouseTable> FilteredWareHouses { get; private set; }
		public IEnumerable GetSuggestions(string filter)
		{
			if (string.IsNullOrWhiteSpace(filter)) return null;
			FilteredWareHouses = ListOfWareHouses
					.Where(state => state.Title.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
					.ToList();
			return
				FilteredWareHouses;
		}

		public WareHouseProvider()
		{
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
				return;
			var repository = App.AppContainer.Resolve(typeof(IWareHouseRepository)) as IWareHouseRepository;
			if (repository.GetAll().Any())
			{
				var products = repository.GetAll()
					.ToList();
				//.GroupBy(x => x.Title)
				//.GroupBy(x => x.Title)

				ListOfWareHouses = products;
			}
		}
	}
}
