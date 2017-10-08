using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteTutorial {

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TransferItemPage : ContentPage {

        public TransferItemPage() {

            InitializeComponent();
        }

        private void TransferPackageButton_Clicked(object sender, EventArgs e) {

        }

        private void PackageListView_ItemTapped(object sender, ItemTappedEventArgs e) {

        }
    }
}