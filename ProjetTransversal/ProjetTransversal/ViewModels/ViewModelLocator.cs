using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public MainPageViewModel MainPage => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public LoginPageViewModel SettingsPage => ServiceLocator.Current.GetInstance<LoginPageViewModel>();
    }
}
