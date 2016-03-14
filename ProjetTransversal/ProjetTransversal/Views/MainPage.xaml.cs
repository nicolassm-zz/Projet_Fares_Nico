using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ProjetTransversal.Models;
using Tweetinvi;
using Tweetinvi.Core.Parameters;

namespace ProjetTransversal.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            //NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var user = e.Parameter as Tuple<string, string>;


            // Get the latest 40 tweets published on your timeline
            var tweets = Timeline.GetHomeTimeline();
            
        }
    }
}
