using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Tweetinvi;
using Tweetinvi.Logic;
using System;

namespace ProjetTransversal.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Tweetinvi.Logic.Tweet> _tweets;

        public ObservableCollection<Tweetinvi.Logic.Tweet> Tweets {
            get { return _tweets; }
            set { Set(ref _tweets, value); }
        }

        public MainPageViewModel()
        {

        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Tweets = new ObservableCollection<Tweetinvi.Logic.Tweet>();
            var tweets = Timeline.GetHomeTimeline();
            foreach (Tweetinvi.Logic.Tweet tweet in tweets)
            {
                //var card = await _cardApi.GetOne(basic.name);
                if (!String.IsNullOrEmpty(tweet.Text))
                {
                    //basic.Image = await _imageLoader.GetFromUrl(basic.img);
                    Tweets.Add(tweet);
                }
            }
        }

    }
}

