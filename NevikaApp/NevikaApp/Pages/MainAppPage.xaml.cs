using NevikaApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;


namespace NevikaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAppPage : ContentPage
    {
        ZXingScannerPage scanPage;


        public MainAppPage()
        {
            InitializeComponent();
            //ButtonActivateScan.Clicked += ButtonActivateScan_Clicked;
            btnScanBarcode.Clicked += ButtonActivateScan_Clicked;
            btnSettingsMenu.Clicked += ButtonSettingsMenu_Clicked;
            btnProfileMenu.Clicked += ButtonProfileMenu_Clicked;
        }

        private void ButtonProfileMenu_Clicked(object sender, EventArgs e)
        {
           
        }

        private void ButtonSettingsMenu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new UserOptionsPage());
        }

        private async void ButtonActivateScan_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    //App.ScannedProduct = product;
                    await Navigation.PopModalAsync();
                    await Navigation.PushModalAsync(new ItemScanned(result.Text));
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }
      
    }
}