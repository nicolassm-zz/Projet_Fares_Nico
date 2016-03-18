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
using System.IO;

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
                    _enterAuth = new RelayCommand(CheckAuthentication);
                    /*var exists = tmp.Result;
                    if (!exists)
                        _enterAuth = new RelayCommand(NavigateToAuth);
                    else _enterAuth = new RelayCommand(NavigateToMain);*/
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

        public async void CheckAuthentication()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            if (File.Exists(storageFolder.Path + "\\tokens.txt"))
            {
                Windows.Storage.StorageFile savedUserFile = await storageFolder.GetFileAsync("tokens.txt");
                NavigateToMain();
            }
            else {
                Windows.Storage.StorageFile savedUserFile = await storageFolder.CreateFileAsync("tokens.txt");
                NavigateToAuth();
            }
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

        public void NavigateToMain()
        {
            var result = ReadFromFile();
            var tokens = result.Result;
            var userCredentials = new TwitterCredentials("PxHS19i96nuyxI1YNd1P5n0cm", "FdLZwVdWx5CCTOZRs95DdEPHYWJQBnA7V0z6EMAnaMcIHHCOQX", tokens.Item1, tokens.Item2);
            Auth.SetCredentials(userCredentials);
            this.NavigationService.Navigate(typeof(Views.MainPage));
        }

        public async Task<Tuple<string,string>> ReadFromFile()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile savedUserFile = await storageFolder.GetFileAsync("tokens.txt");

            var stream = await savedUserFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

            ulong size = stream.Size;
            string text;

            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    text = dataReader.ReadString(numBytesLoaded);
                }
            }

            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var result = new Tuple<string,string>(lines[0], lines[1]);
            return result;
            
        }
    }
}
