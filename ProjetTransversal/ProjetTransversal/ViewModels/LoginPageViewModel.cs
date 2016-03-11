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
        private RelayCommand _login;
        private string _inputName;
        private string _inputPw;

        public RelayCommand Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new RelayCommand(NavigateToAuth);
                }
                return _login;
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

            // Create a new set of credentials for the application
            var appCredentials = new TwitterCredentials("PxHS19i96nuyxI1YNd1P5n0cm", "FdLZwVdWx5CCTOZRs95DdEPHYWJQBnA7V0z6EMAnaMcIHHCOQX");

            // Go to the URL so that Twitter authenticates the user and gives him a PIN code
            var url = CredentialsCreator.GetAuthorizationURL(appCredentials);

            this.NavigationService.Navigate(typeof(Views.AuthPage), url);
            //Frame Frame = Window.Current.Content as Frame;
            //this.Frame.Navigate(typeof(Views.MainPage), user);
        }
    }
}
