using WareHouse.Identity;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows;

namespace WareHouse.ViewModels.ViewModelBase
{
    public class AuthenticationViewModelBase : BindableBase
    {
        private readonly IAuthenticationService _authenticationService;
        public virtual DelegateCommand<PasswordBox> LoginCommand { get; private set; }
        public virtual DelegateCommand<Window> ExitCommand { get; private set; }
        private string _username;
        private string _status;
        #region Properties
        public string UserName
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged(); }
        }

        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole("Administrators") ? "You are an administrator!"
                              : "You are NOT a member of the administrators group.");

                return "Not authenticated!";
            }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("Status"); }
        }
        #endregion

        public AuthenticationViewModelBase(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LoginCommand = new DelegateCommand<PasswordBox>(Login);
            ExitCommand = new DelegateCommand<Window>(CloseWindow);

        }

        private void CloseWindow(Window window)
        {
            window?.Close();
        }


        private void Login(PasswordBox parameter)
        {
            try
            {
                User user = _authenticationService.AuthenticateUser(UserName, parameter.Password);

                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                customPrincipal.Identity = new CustomIdentity(user.UserName, user.Email,user.Password ,user.Role);

                ShowView(customPrincipal);
                Status = string.Empty;
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Неправильный логин или пароль";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
          //  var s = Thread.CurrentPrincipal.Identity.IsAuthenticated;

        }

        //private void Logout(object parameter)
        //{
        //    CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
        //    if (customPrincipal != null)
        //    {
        //        customPrincipal.Identity = new AnonymousIdentity();
        //        RaisePropertyChanged("AuthenticatedUser");
        //        RaisePropertyChanged("IsAuthenticated");
        //        Status = string.Empty;
        //    }
        //}

        public bool IsAuthenticated
        {
            get { return true; } //Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        protected virtual void ShowView(CustomPrincipal customPrincipal)
        {

        }
     
    }
}
