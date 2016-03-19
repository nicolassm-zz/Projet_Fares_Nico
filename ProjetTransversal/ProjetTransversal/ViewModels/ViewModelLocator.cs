using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ProjetTransversal.ViewModels
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //SimpleIoc.Default.Register<ICardApi, CardApi>();
            //SimpleIoc.Default.Register<IImageLoader, ImageLoader>();

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<AuthPageViewModel>();
            SimpleIoc.Default.Register<UserTimelinePageViewModel>();
        }

        public MainPageViewModel MainPage => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public LoginPageViewModel LoginPage => ServiceLocator.Current.GetInstance<LoginPageViewModel>();
        public AuthPageViewModel AuthPage => ServiceLocator.Current.GetInstance<AuthPageViewModel>();
        public UserTimelinePageViewModel UserTimelinePage => ServiceLocator.Current.GetInstance<UserTimelinePageViewModel>();

    }
}
