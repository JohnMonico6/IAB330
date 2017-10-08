using SqliteTutorial.Core.Models;
using SqliteTutorial.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteTutorial {

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class BrowsePackagePage : ContentPage {

        public BrowsePackagePage() {
            InitializeComponent();
            BindingContext = new BrowsePackageVM();
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var package = e.SelectedItem as Package;
            var pvm = new PackagePageVM(package);
            var page = new PackagePage()
            {
                BindingContext = pvm
            };
            Navigation.PushAsync(page);
        }

        //This probably needs to be setup through MVVM but I think it might require some restructuring
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {

            var source = BindingContext as BrowsePackageVM;

            PackagesListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue)) {
                PackagesListView.ItemsSource = source.Packages;
            } else {
                PackagesListView.ItemsSource = source.Packages.Where(i => i.Name.Contains(e.NewTextValue) || 
                i.Room.Contains(e.NewTextValue) || i.Items.Contains(e.NewTextValue));
            }

            PackagesListView.EndRefresh();
        }
    }

}