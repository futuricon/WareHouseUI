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
	public class ProductProvider :ISuggestionProvider
	{
		public IEnumerable<Product> ListOfProducts { get; set; }

		public static IEnumerable<Product> FilteredProducts { get; private set; }
		public IEnumerable GetSuggestions(string filter)
		{
			if (string.IsNullOrWhiteSpace(filter)) return null;
			FilteredProducts = ListOfProducts
					.Where(state => state.Title.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
					.ToList();
			return
				FilteredProducts;
		}

		public ProductProvider()
		{
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
				return;
			var repository = App.AppContainer.Resolve(typeof(IProductRepository)) as IProductRepository;
			var products = repository.Products.GroupBy(x=>x.Title).FirstOrDefault();
			ListOfProducts = products;
		}
	}
}
