using GalaSoft.MvvmLight.Command;
using ProjetTransversal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Tweetinvi;

namespace ProjetTransversal.ViewModels
{
    class AuthPageViewModel : ViewModelBase
    {
        private string _authPin;
        private RelayCommand _login;

        public string AuthPin
        {
            get { return _authPin; }
            set { Set(ref _authPin, value);
                var userCredentials = CredentialsCreator.GetCredentialsFromVerifierCode(value, Authentication.AppCredentials);
                Auth.SetCredentials(userCredentials);
            }
        }

        public RelayCommand Login {
            get
            {
                if (_login == null)
                {
                    _login = new RelayCommand(NavigateToMain);
                }
                return _login;
            }
        }

        public void NavigateToMain() {
            this.NavigationService.Navigate(typeof(Views.MainPage));
        }

    }
}
