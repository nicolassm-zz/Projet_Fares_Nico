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
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Tweetinvi.Logic.Tweet> _tweets;
        private string _contentImage;
        private Tweetinvi.Logic.User _mainUser;
        private RelayCommand<string> _like;
        private RelayCommand<string> _reply;
        private RelayCommand<string> _retweet;
        private RelayCommand<string> _userTimeline;

        public RelayCommand<string> UserTimeline
        {
            get
            {
                if (_userTimeline == null)
                {
                    _userTimeline = new RelayCommand<string>(GoToUserTimeline);
                }
                return _userTimeline;
            }
        }

        private void GoToUserTimeline(string param)
        {
            this.NavigationService.Navigate(typeof(Views.UserTimelinePage), param);
        }

        public RelayCommand<string> Like
        {
            get
            {
                if (_like == null)
                {
                    _like = new RelayCommand<string>(LikeTweet);
                }
                return _like;
            }
        }

        private void LikeTweet(string param)
        {
            var id = Int64.Parse(param);
            Tweetinvi.Tweet.FavoriteTweet(id);
        }

        public RelayCommand<string> Reply
        {
            get
            {
                if (_reply == null)
                {
                    _reply = new RelayCommand<string>(ReplyTweet);
                }
                return _reply;
            }
        }

        private async void ReplyTweet(string param)
        {
            var id = Int64.Parse(param);
            var dialog = new ContentDialog();

            dialog.MaxWidth = dialog.ActualWidth;

            

            var panel = new StackPanel();
            var replyMessage = new TextBox();

            panel.Children.Add(replyMessage);

            dialog.Content = panel;

            dialog.PrimaryButtonText = "Reply";

            var tweetToReplyTo = Tweetinvi.Tweet.GetTweet(id);



            dialog.PrimaryButtonCommand = new RelayCommand(() =>
            {
                var textToPublish = string.Format("@{0} {1}", tweetToReplyTo.CreatedBy.ScreenName, replyMessage.Text);
                var tweet = Tweetinvi.Tweet.PublishTweetInReplyTo(textToPublish, id);
            });

            dialog.SecondaryButtonText = "Cancel";
            dialog.SecondaryButtonCommand = new RelayCommand(() => { dialog.Hide(); });

            var result = await dialog.ShowAsync();

        }

        public RelayCommand<string> Retweet
        {
            get
            {
                if (_retweet == null)
                {
                    _retweet = new RelayCommand<string>(RetweetTweet);
                }
                return _retweet;
            }
        }

        private void RetweetTweet(string param)
        {
            var id = Int64.Parse(param);
            Tweetinvi.Tweet.PublishRetweet(id);
        }

        public Tweetinvi.Logic.User MainUser
        {
            get { return _mainUser; }
            set { Set(ref _mainUser, value); }
        }

        public string ContentImage {
            get { return _contentImage; }
            set { Set(ref _contentImage, value); }
        }

        public ObservableCollection<Tweetinvi.Logic.Tweet> Tweets {
            get { return _tweets; }
            set { Set(ref _tweets, value); }
        }

        public MainPageViewModel()
        {
            MainUser = Tweetinvi.User.GetAuthenticatedUser() as Tweetinvi.Logic.User;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Tweets = new ObservableCollection<Tweetinvi.Logic.Tweet>();
            var tweets = Timeline.GetHomeTimeline();
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

