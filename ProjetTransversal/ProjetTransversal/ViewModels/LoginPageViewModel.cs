using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetTransversal.Models;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Template10.Services.NavigationService;
using GalaSoft.MvvmLight.Views;
using Template10.Mvvm;
using GalaSoft.MvvmLight.Command;
using Tweetinvi.Core.Credentials;
using Tweetinvi;

namespace ProjetTransversal.ViewModels
{
    class LoginPageViewModel : ViewModelBase
    {
        private RelayCommand _enterAuth;
        private string _inputName;
        private string _inputPw;

        public RelayCommand EnterAuth
        {
            get
            {
                if (_enterAuth == null)
                {
                    _enterAuth = new RelayCommand(NavigateToAuth);
                }
                return _enterAuth;
            }
        }

        public string InputName
        {
            get { return _inputName; }
            set { Set(ref _inputName, value); }
        }

        public string InputPw
        {
            get { return _inputPw; }
            set { Set(ref _inputPw, value); }
        }

        public void NavigateToAuth()
        {

            Models.User.user.username = _inputName;
            Models.User.user.password = _inputPw;

            // Go to the URL so that Twitter authenticates the user and gives him a PIN code
            Authentication.AppCredentials = new TwitterCredentials("PxHS19i96nuyxI1YNd1P5n0cm", "FdLZwVdWx5CCTOZRs95DdEPHYWJQBnA7V0z6EMAnaMcIHHCOQX");
            Authentication.AuthUrl = CredentialsCreator.GetAuthorizationURL(Authentication.AppCredentials);

            this.NavigationService.Navigate(typeof(Views.AuthPage));
            //Frame Frame = Window.Current.Content as Frame;
            //this.Frame.Navigate(typeof(Views.MainPage), user);
        }
    }
}
