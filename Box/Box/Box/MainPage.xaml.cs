using SqliteTutorial.Core.Interfaces;
using SqliteTutorial.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteTutorial
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }

        private void AddPackageButton_Clicked(object sender, EventArgs e) {

            Navigation.PushAsync(new AddPackagePage());
        }

        private void BrowsePackageButton_Clicked(object sender, EventArgs e) {

            Navigation.PushAsync(new BrowsePackagePage());
        }

        private void QRScannerButton_Clicked(object sender, EventArgs e) {

            Navigation.PushAsync(new QRScannerPage());
        }

        private void ExportDatabaseButton_Clicked(object sender, EventArgs e) {

            Navigation.PushAsync(new PackagePage());
        }

    }
}
