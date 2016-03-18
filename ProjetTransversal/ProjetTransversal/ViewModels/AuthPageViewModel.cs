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
using Windows.UI.Xaml.Navigation;

namespace ProjetTransversal.ViewModels
{
    class AuthPageViewModel : ViewModelBase
    {
        private string _authPin;
        private RelayCommand _login;
        private Tweetinvi.Core.Credentials.TwitterCredentials _userCredentials;

        public Tweetinvi.Core.Credentials.TwitterCredentials UserCredentials {
            get { return _userCredentials; }
            set { Set(ref _userCredentials, value); }
        }

        public string AuthPin
        {
            get { return _authPin; }
            set { Set(ref _authPin, value);
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
            UserCredentials = CredentialsCreator.GetCredentialsFromVerifierCode(AuthPin, Authentication.AppCredentials) as Tweetinvi.Core.Credentials.TwitterCredentials;
            Auth.SetCredentials(UserCredentials);
            SaveToFileAsync();

            this.NavigationService.Navigate(typeof(Views.MainPage));
        }

        
        public async Task SaveToFileAsync()
        {   
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile savedUserFile = await storageFolder.GetFileAsync("tokens.txt");

            var stream = await savedUserFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(UserCredentials.AccessToken + "\r\n" + UserCredentials.AccessTokenSecret);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose();

        }
        
    }
}
