using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace NevikaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanningPage : ContentPage
    {
        public ScanningPage()
        {
            InitializeComponent();
            BarcodeScanView.IsVisible = true;
            BarcodeScanView.IsScanning = true;
        }

        public void Scan_Barcode(object sender, EventArgs e)
        {

        }

        public void Handle_OnScanResult(Result result)
        {
            BarcodeScanView.IsVisible = false;
            BarcodeScanView.IsScanning = false;
            Application.Current.MainPage = new NewBookPage();
            //Application.Current.MainPage = new NavigationPage(new ItemScanned("456456"));
            //Navigation.PushAsync(new ItemScanned("456456"));
            //Navigation.PushAsync(new NewBookPage());
            //Console.WriteLine(result.Text);
        }
    }
}