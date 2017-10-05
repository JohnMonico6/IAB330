using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteTutorial {
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class BrowsePackagePage : ContentPage {

        //Debug to fill ListView
        ObservableCollection<Packages> packageList = new ObservableCollection<Packages>();

        public BrowsePackagePage() {

            InitializeComponent();

            //debug to fill ListView
            PackageListView.ItemsSource = packageList;
            packageList.Add(new Packages { PackageName = "Kitchen One", Destination = "Kitchen" });
            packageList.Add(new Packages { PackageName = "Loungroom Games", Destination = "Loungroom" });
            packageList.Add(new Packages { PackageName = "Clothing", Destination = "Master Bedroom" });
            packageList.Add(new Packages { PackageName = "Misc Stuff" , Destination = "Garage"});
        }

        private void PackageListView_ItemTapped(object sender, ItemTappedEventArgs e) {
           
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {

            PackageListView.BeginRefresh();

            if(string.IsNullOrWhiteSpace(e.NewTextValue)) {
                PackageListView.ItemsSource = packageList;
            } else {
                PackageListView.ItemsSource = packageList.Where(i => i.PackageName.Contains(e.NewTextValue));
            }
            PackageListView.EndRefresh();
        }
    }

    //Debug class to fill ListView
    public class Packages {

        public string PackageName { get; set;}
        public string Destination { get; set;}
    }
}