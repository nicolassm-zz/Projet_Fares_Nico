using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetTransversal.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

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
                    _login = new RelayCommand(NavigateToMain);
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

        public void NavigateToMain()
        {
            User User = new User();

            User.username = InputName;
            User.password = InputPw;
            var user = new Tuple<string, string>(InputName, InputPw);
            

            Frame Frame = Window.Current.Content as Frame;
            Frame.Navigate(typeof(Views.MainPage), user);
        }
    }
}
