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

			Log.Information("Bigin registrating dependencies");
			containerRegistry.RegisterInstance(Log.Logger);//Log
			containerRegistry.RegisterInstance(config);//IConfigurationRoot
			containerRegistry.Register<IConnectionHelper, ConnectionHelper>();
			containerRegistry.Register<IConfigurationHelper, ConnectionHelper>();
			containerRegistry.Register<ApplicationDbContext>();
			containerRegistry.Register<IProductRepository, ProductRepositroy>();
			containerRegistry.Register<ISynchronizeFactory, SynchronizeFactory>();
			Log.Information("Finish registrating dependencies");

		}

	}
}
