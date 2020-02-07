using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Unity;
using Serilog;
using WareHouse.Dialogs;
using WareHouse.Identity;
using WareHouse.Models.Context;
using WareHouse.Models.Infrastructure;
using WareHouse.Models.Repositories;
using WareHouse.Views;

namespace WareHouse
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		public static IContainerProvider AppContainer { get; private set; }

		protected override Window CreateShell()
		{
			AppContainer = Container;
			return Container.Resolve<MainView>();
		}
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
			string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
			var config = configurationBuilder.AddJsonFile(path, false).Build();
			Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.WriteTo.File("logs\\my_log.log")
			.CreateLogger();
			Log.Information("\n\n");
			Log.Information("Bigin registrating dependencies");
			containerRegistry.RegisterInstance(Log.Logger);//Log
			containerRegistry.RegisterInstance(config);//IConfigurationRoot
			containerRegistry.Register<IConnectionHelper, ConnectionHelper>();
			containerRegistry.Register<IConfigurationHelper, ConnectionHelper>();
			containerRegistry.Register<ApplicationDbContext>();		
			containerRegistry.Register<ISynchronizeFactory, SynchronizeFactory>();
			containerRegistry.Register<IAuthenticationService, AuthenticationService>();
			containerRegistry.Register<IUserRepository, UserRepository>();
			containerRegistry.Register<IIncomeRepository, IncomeRepository>();
			containerRegistry.Register<IProductRepository, ProductRepository>();
			containerRegistry.Register<IWareHouseRepository, WareHouseRepository>();
			containerRegistry.Register<IExpenseRepository, ExpenseRepository>();
			containerRegistry.Register<IClientRepository, ClientRepositroy>();
			containerRegistry.Register<IProviderRepository, ProviderRepository>();
			containerRegistry.Register<IOrderRepository, OrderRepository>();
			containerRegistry.Register<ICategoryRepository, CategoryRepository>();

			containerRegistry.Register<SeedData>();
			containerRegistry.RegisterDialog<NewWareHouseDialog, NewWareHouseDialogViewModel>();
			containerRegistry.RegisterDialog<NewIncomeDialog, NewIncomeDialogViewModel>();
			containerRegistry.RegisterDialog<NewExpensesDialog, NewExpenseDialogViewModel>();
			containerRegistry.RegisterDialog<NewRealizationDialog, NewRealizationDialogViewModel>();
			//containerRegistry.RegisterDialog<NewReturnDialog, NewRealizationDialogViewModel>();
			containerRegistry.RegisterDialog<NewClientDialog, DialogDiliverClientViewModel>();
			containerRegistry.RegisterDialog<NewProviderDialog, DialogDiliverClientViewModel>();
			containerRegistry.RegisterDialog<NewProductDialog, NewProductDialogViewModel>();
			containerRegistry.RegisterDialog<NewCategoryDialog, NewCategoryViewModel>();

			Log.Information("Finish registrating dependencies");

		}

	}
}
