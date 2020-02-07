using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Unity;
using WareHouse.Identity;
using WareHouse.ViewModels.ViewModelBase;
using WareHouse.Views;

namespace WareHouse.ViewModels
{
	public class LoginViewModel : AuthenticationViewModelBase
	{
		IUnityContainer _container;

		public LoginViewModel(IAuthenticationService authenticationService, IUnityContainer container) :base(authenticationService)
		{
			_container = container;

		}

		protected override void ShowView(CustomPrincipal customPrincipal)
		{
			 _container.Resolve<MainView>().Show();			
		}

	}
}
