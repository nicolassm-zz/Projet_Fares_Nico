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
using System.IO;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Xaml;

namespace ProjetTransversal.ViewModels
{
    class UserTimelinePageViewModel : ViewModelBase
    {
        private ObservableCollection<Tweetinvi.Logic.Tweet> _tweets;
        private string _contentImage;

        public string ContentImage
        {
            get { return _contentImage; }
            set { Set(ref _contentImage, value); }
        }

        public ObservableCollection<Tweetinvi.Logic.Tweet> Tweets
        {
            get { return _tweets; }
            set { Set(ref _tweets, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var paramStr = parameter as string;
            var id = Int64.Parse(paramStr);

            Tweets = new ObservableCollection<Tweetinvi.Logic.Tweet>();
            var tweets = Timeline.GetUserTimeline(id);
            foreach (Tweetinvi.Logic.Tweet tweet in tweets)
            {
                if (!String.IsNullOrEmpty(tweet.Text))
                {
                    Tweets.Add(tweet);
                    var media = tweet.Media;
                    if (media.Count != 0)
                    {
                        ContentImage = tweet.Media[0].MediaURL;
                    }
                }
            }
        }
    }
}
