using NevikaApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NevikaApp
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();

            splashImage = new Image()
            {
                Source = "nevikaLogo.png",
                WidthRequest = 150,
                HeightRequest = 150
            };

            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);
            this.BackgroundColor = Color.FromHex("#ffffff"); // #429de3
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000);
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            //await splashImage.ScaleTo(150, 1200, Easing.Linear);
            await splashImage.FadeTo(0, 1000, Easing.Linear);

            // True is to show platform specific transition animation
            //await this.Navigation.PushAsync(new ScanningPage(), true);

            Application.Current.MainPage = new MainAppPage();
           
            //Application.Current.MainPage = new NavigationPage(new MainAppPage());
            //Application.Current.MainPage = new NavigationPage(new ItemScanned("456456"));

        }
    }
}
